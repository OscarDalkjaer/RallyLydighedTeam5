using API.ViewModels;
using Core.Domain.Entities;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
    protected EventController() { }

    private IEventRepository _eventRepository;

    public EventController(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }


    [HttpPost]
    public async Task<IActionResult> AddEvent([FromBody] AddEventRequest request)
    {
        if (request == null) return BadRequest("ViewModel was null");
        Event @event = request.ConvertToEvent();

        await _eventRepository.AddEvent(@event);

        AddEventResponse response = AddEventResponse.ConvertToAddEventResponse(@event);
        return Ok(response);
    }


    [HttpGet("{eventId}", Name = "GetEvent")]
    public async Task<IActionResult> GetEvent(int eventId)
    {
        if (eventId <= 0) return BadRequest("eventId must be larger than 0");

        Event? @event = await _eventRepository.GetEvent(eventId);

        if (@event == null) return NotFound($"Event with id {eventId} not found");

        GetEventResponse getEventViewModel = GetEventResponse.ConvertFromEvent(@event);
        return Ok(getEventViewModel);
    }

    [HttpGet(Name = "GetALlEvents")]
    public async Task<IActionResult> GetAllEvents()
    {
        IEnumerable<Event> events = await _eventRepository.GetAllEvents();
        GetAllEventsResponse getAllEventsViewModel = GetAllEventsResponse.ConvertFromEvents(events);

        return getAllEventsViewModel.Events.Count is 0
            ? NoContent()
            : Ok(getAllEventsViewModel);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEvent([FromBody] UpdateEventRequest updateEventRequestViewModel)
    {
        if (updateEventRequestViewModel is null) return BadRequest("updateviewmodel is null");
        Event updatedEvent = updateEventRequestViewModel.ConvertToEvent();

        await _eventRepository.UpdateEvent(updatedEvent);

        UpdateEventResponse updateEventResponseViewModel =UpdateEventResponse.ConvertFromEvent(updatedEvent);
        return Ok(updateEventResponseViewModel);
    }


    [HttpDelete]
    public async Task<IActionResult> DeleteEvent(int eventId)
    {
        await _eventRepository.DeleteEvent(eventId);
        return Ok();
    }
}
