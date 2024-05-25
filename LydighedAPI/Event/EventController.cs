using API.ViewModels;
using Core.Domain.Entities;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
    private IEventRepository _eventRepository;

    public EventController(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    [HttpPost]
    public async Task<ActionResult<AddEventResponse>> AddEvent([FromBody] AddEventRequest addEventRequest)
    {
        if (addEventRequest == null) return BadRequest("ViewModel was null");
        Event @event = addEventRequest.ConvertToEvent();

        await _eventRepository.AddEvent(@event);

        AddEventResponse response = AddEventResponse.ConvertToAddEventResponse(@event);
        return Ok(response);
    }


    [HttpGet("{eventId}", Name = "GetEvent")]
    public async Task<ActionResult<GetEventResponse>> GetEvent(int eventId)
    {
        if (eventId <= 0) return BadRequest("eventId must be larger than 0");
        Event? @event = await _eventRepository.GetEvent(eventId);

        if (@event == null) return NotFound($"Event with id {eventId} not found");
        GetEventResponse getEventResponse = GetEventResponse.ConvertFromEvent(@event);

        return Ok(getEventResponse);
    }

    [HttpGet(Name = "GetALlEvents")]
    public async Task<ActionResult<GetAllEventsResponse>> GetAllEvents()
    {
        IEnumerable<Event> events = await _eventRepository.GetAllEvents();
        GetAllEventsResponse getAllEventsResponse = GetAllEventsResponse.ConvertFromEvents(events);

        return getAllEventsResponse.IsEmpty()
            ? NoContent()
            : Ok(getAllEventsResponse);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateEventResponse>> UpdateEvent([FromBody] UpdateEventRequest updateEventRequest)
    {
        if (updateEventRequest is null) return BadRequest("updateviewmodel is null");
        Event updatedEvent = updateEventRequest.ConvertToEvent();

        await _eventRepository.UpdateEvent(updatedEvent);
        UpdateEventResponse updateEventResponse = UpdateEventResponse.ConvertFromEvent(updatedEvent);

        return Ok(updateEventResponse);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteEvent(int eventId)
    {
        await _eventRepository.DeleteEvent(eventId);
        return Ok();
    }
}
