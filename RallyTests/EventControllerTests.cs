using API.Controllers;
using API.ViewModels;
using BusinessLogic.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RallyTests
{
    [TestClass]
    public class EventControllerTests
    {

        [TestMethod]
        public async Task TestAddEvent()
        {
            //Arrange
            EventTestRepository eventTestRepository = new EventTestRepository();
            EventController eventController = new EventController(eventTestRepository);
            eventTestRepository.Events.Clear();

            //Act
            eventController.AddEvent(new AddEventViewModel("KoldingCup", new DateTime(2023, 03, 02), "6000 Kolding"));

            //Assert
            Assert.AreEqual(eventTestRepository.Events.Count, 1);

        }

        [TestMethod]
        public async Task TestGetEvent()
        {
            //Arrange
            EventTestRepository eventTestRepository = new EventTestRepository();
            EventController eventController = new EventController(eventTestRepository);
            await eventTestRepository.AddEvent(new Event("KoldingCup", new DateTime(2023, 03, 02), "6000 Kolding"));

            //Act
            OkObjectResult result = (OkObjectResult)await eventController.GetEvent(1);
            GetEventViewModel getEventViewModel = (GetEventViewModel)result.Value!;
            
            //Assert
            Assert.AreEqual(getEventViewModel.EventId, 1);
            Assert.AreEqual(getEventViewModel.Name, "KoldingCup");
            Assert.AreEqual(getEventViewModel.Date, new DateTime(2023, 03, 02));
            Assert.AreEqual(getEventViewModel.Location, "6000 Kolding");

        }

        [TestMethod]
        public async Task TestGetAllEvents()
        {
            //Arrange
            EventTestRepository eventTestRepository = new EventTestRepository();
            EventController eventController = new EventController(eventTestRepository);
            await eventTestRepository.AddEvent(new Event("KoldingCup", new DateTime(2023, 03, 02), "6000 Kolding"));
            await eventTestRepository.AddEvent(new Event("KoldingCup", new DateTime(2024, 03, 02), "6000 Kolding"));

            //Act
            Task<IEnumerable<GetEventViewModel>> events = eventController.GetAllEvents();
            List<GetEventViewModel> eventList = events.Result.ToList();

            //Assert
            Assert.AreEqual(2, eventList.Count);
        }

        [TestMethod]

        public async Task TestUpdateEvent()
        {
            //Arrange
            EventTestRepository eventTestRepository = new EventTestRepository();
            EventController eventController = new EventController(eventTestRepository);
            await eventController.AddEvent(new AddEventViewModel("RoskildeTurnering", new DateTime(2024, 02, 02), "4000 Roskilde"));
            UpdateEventViewModel updateEventViewModel = new UpdateEventViewModel("UpdatedRoskildeTurnering", new DateTime(2024, 04, 04), "4500 Nykøbing Sj.", 1);

            //Act
            await eventController.UpdateModel(updateEventViewModel);

            //Assert
            Assert.AreEqual(eventTestRepository.Events[0].EventId, 1);
            Assert.AreEqual(eventTestRepository.Events[0].Name, "UpdatedRoskildeTurnering");
            Assert.AreEqual(eventTestRepository.Events[0].Date, new DateTime(2024, 04, 04));
            Assert.AreEqual(eventTestRepository.Events[0].Location, "4500 Nykøbing Sj.");

        }

        [TestMethod]
        public async Task TestDeleteEvent() 
        {
            //Arrange
            EventTestRepository eventTestRepository = new EventTestRepository();
            EventController eventController = new EventController(eventTestRepository);
            await eventController.AddEvent(new AddEventViewModel("RoskildeTurnering", new DateTime(2024, 02, 02), "4000 Roskilde"));
            int count1 = eventTestRepository.Events.Count;

            //Act
            eventController.DeleteEvent(1);
            int count2 = eventTestRepository.Events.Count;

            //Assert
            Assert.AreEqual(count1-1, count2);


        }

       

       

    }
}
