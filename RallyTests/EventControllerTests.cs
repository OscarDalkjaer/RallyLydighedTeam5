using API.Controllers;
using API.ViewModels;
using Core.Domain.Entities;
using Infrastructure;
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

        AddEventRequest addEventViewModel = new AddEventRequest()
        {
            Name = "KoldingCup",
            Date = new DateTime(2023, 03, 02),
            Location = "6000 Kolding"
        };

        //Act
        await _eventController.AddEvent(addEventViewModel);

        //Assert
        Assert.AreEqual(1, _eventTestRepository.TestEvents.Count);

    }

    [TestMethod]
    public async Task TestGetEvent()
    {
        //Arrange
        await _eventTestRepository.AddEvent(new Event("KoldingCup", new DateTime(2023, 03, 02), "6000 Kolding", 1));

        //Act
        GetEventResponse getEventViewModel = (await _eventController.GetEvent(1)).GetValueAs<GetEventResponse>();


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
        GetAllEventsResponse getAllEventsViewModel = (await _eventController.GetAllEvents()).GetValueAs<GetAllEventsResponse>();

        //Assert
        Assert.AreEqual("KoldingCup", getAllEventsViewModel.Events[0].Name);
        Assert.AreEqual(new DateTime(2023, 03, 02), getAllEventsViewModel.Events[0].Date);
        Assert.AreEqual("6000 Kolding", getAllEventsViewModel.Events[0].Location);

        Assert.AreEqual("KoldingCup", getAllEventsViewModel.Events[1].Name);
        Assert.AreEqual(new DateTime(2024, 03, 02), getAllEventsViewModel.Events[1].Date);
        Assert.AreEqual("6000 Kolding", getAllEventsViewModel.Events[1].Location);
    }

    [TestMethod]

    public async Task TestUpdateEvent()
    {
        //Arrange
        Event @event = new Event("RoskildeTurnering", new DateTime(2024, 02, 02), "4000 Roskilde", eventId: 1);
        await _eventTestRepository.AddEvent(@event);

        UpdateEventRequest updateEventRequestViewModel = new UpdateEventRequest
        {
            UpdateEventId = 1,
            Name = "UpdatedRoskildeTurnering",
            Date = new DateTime(2024, 04, 04),
            Location = "4500 Nykøbing Sj."
        };

        //Act
        UpdateEventResponse response = (await _eventController.UpdateEvent(updateEventRequestViewModel)).GetValueAs();

        //Assert
        Assert.AreEqual("UpdatedRoskildeTurnering", response.Name);
        Assert.AreEqual(new DateTime(2024, 04, 04), response.Date);
        Assert.AreEqual("4500 Nykøbing Sj.", response.Location);
    }

    [TestMethod]
    public async Task TestDeleteEvent()
    {
        //Arrange
        Event request = new Event("RoskildeTurnering", new DateTime(2024, 02, 02), "4000 Roskilde", 1);
        await _eventTestRepository.AddEvent(request);

        //Act
        IActionResult result = await _eventController.DeleteEvent(1);

        //Assert
        Assert.IsInstanceOfType<OkResult>(result);
        Assert.AreEqual(0, _eventTestRepository.TestEvents.Count);
    }
}
