using API.Controllers;
using BusinessLogic.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTests
{
    [TestClass]
    public class EventControllerTests
    {
                
        [TestMethod]
        public void TestAddEvent() 
        {
            //Arrange
            EventTestRepository eventTestRepository = new EventTestRepository();
            EventController eventController = new EventController(eventTestRepository);
            eventTestRepository.Events.Clear();

            //Act
            eventController.AddEvent(new Event("KoldingCup", new DateOnly(2024, 5, 2), "6000 Kolding"));

            //Assert
            Assert.AreEqual(eventTestRepository.Events.Count, 1);           

        }


    }
}
