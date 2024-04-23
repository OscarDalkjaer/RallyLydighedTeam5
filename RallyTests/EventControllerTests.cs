using API.Controllers;
using API.ViewModels;
using BusinessLogic.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace RallyTests;

[TestClass]
public class EventControllerTests
{
    private readonly EventTestRepository _eventTestRepository;
    private readonly EventController _eventController;
    public EventControllerTests() 
    {
        _eventTestRepository = new EventTestRepository();
        _eventController = new EventController(_eventTestRepository);

    }

    [TestMethod]
    public async Task TestAddEvent()
    {
        //Arrange
        
        AddEventViewModel addEventViewModel = new AddEventViewModel("KoldingCup", new DateTime(2023, 03, 02), "6000 Kolding");

        //Act
        await _eventController.AddEvent(addEventViewModel);

        //Assert
        Assert.AreEqual(1, _eventTestRepository.TestEvents.Count);

    }

    [TestMethod]
    public async Task TestGetEvent()
    {
        //Arrange
       await _eventTestRepository.AddEvent(new Event("KoldingCup", new DateTime(2023, 03, 02), "6000 Kolding"));

        //Act
        GetEventViewModel getEventViewModel = (await _eventController.GetEvent(1)).GetValueAs<GetEventViewModel>();
                
    
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
        await _eventTestRepository.AddEvent(new Event("KoldingCup", new DateTime(2023, 03, 02), "6000 Kolding"));
        await _eventTestRepository.AddEvent(new Event("KoldingCup", new DateTime(2024, 03, 02), "6000 Kolding"));

        //Act
        GetAllEventsViewModel getAllEventsViewModel = (await _eventController.GetAllEvents()).GetValueAs<GetAllEventsViewModel>();

        //Assert
        Assert.AreEqual(1, getAllEventsViewModel.Events[0].EventId);
        Assert.AreEqual(2, getAllEventsViewModel.Events[1].EventId);
        Assert.AreEqual("KoldingCup", getAllEventsViewModel.Events[0].Name);
        Assert.AreEqual("KoldingCup",getAllEventsViewModel.Events[1].Name);
        Assert.AreEqual(new DateTime(2023, 03, 02), getAllEventsViewModel.Events[0].Date);
        Assert.AreEqual(new DateTime(2024, 03, 02), getAllEventsViewModel.Events[1].Date);
        Assert.AreEqual("6000 Kolding", getAllEventsViewModel.Events[0].Location);
        Assert.AreEqual("6000 Kolding", getAllEventsViewModel.Events[1].Location);


    }



    [TestMethod]

    public async Task TestUpdateEvent()
    {
        //Arrange
        await _eventController.AddEvent(new AddEventViewModel("RoskildeTurnering", new DateTime(2024, 02, 02), "4000 Roskilde"));
        UpdateEventViewModel updateEventViewModel = new UpdateEventViewModel("UpdatedRoskildeTurnering", new DateTime(2024, 04, 04), "4500 Nykøbing Sj.", 1);

        //Act
        IActionResult result = await _eventController.UpdateEvent(updateEventViewModel);

        //Assert
        Assert.IsInstanceOfType<OkObjectResult>(result);
        Assert.AreEqual(1, _eventTestRepository.TestEvents[0].EventId );
        Assert.AreEqual("UpdatedRoskildeTurnering", _eventTestRepository.TestEvents[0].Name);
        Assert.AreEqual(new DateTime(2024, 04, 04), _eventTestRepository.TestEvents[0].Date);
        Assert.AreEqual("4500 Nykøbing Sj.", _eventTestRepository.TestEvents[0].Location);

    }

    [TestMethod]
    public async Task TestDeleteEvent() 
    {
        //Arrange
        await _eventController.AddEvent(new AddEventViewModel("RoskildeTurnering", new DateTime(2024, 02, 02), "4000 Roskilde"));
        
        //Act
        IActionResult result = await _eventController.DeleteEvent(1);
        
        //Assert
        Assert.IsInstanceOfType<OkObjectResult>( result );
        Assert.AreEqual(0, _eventTestRepository.TestEvents.Count);

    }





}
