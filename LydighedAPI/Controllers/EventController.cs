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
    public async Task<IActionResult> AddEvent([FromBody] AddEventRequestViewModel addEventRequestViewModel)
    {
        if (addEventRequestViewModel == null) return BadRequest("ViewModel was null");

        Event @event = new Event(addEventRequestViewModel.Name, addEventRequestViewModel.Date, addEventRequestViewModel.Location); //event is a keyword in c#, therefore @
        await _eventRepository.AddEvent(@event);

        AddEventResponseViewModel addEventResponseViewModel = new AddEventResponseViewModel(
            @event.Name,
            @event.Date,
            @event.Location,
            @event.EventId);

        return Ok();        
    }


    [HttpGet("{eventId}", Name = "GetEvent")]
    public async Task<IActionResult> GetEvent(int eventId)
    {
        if (eventId <= 0) return BadRequest("eventId must be larger than 0");
                  
        Event? @event = await _eventRepository.GetEvent(eventId);
            
        if (@event == null) return NotFound($"Event with id {eventId} not found");
        
        GetEventViewModel getEventViewModel = new GetEventViewModel(
        @event.Name, @event.Date, @event.Location, @event.EventId);
        return Ok(getEventViewModel);                  
    }


    [HttpGet(Name ="GetALlEvents")]
    public async Task<IActionResult> GetAllEvents()
    {
        IEnumerable<Event> events = await _eventRepository.GetAllEvents();
        GetAllEventsViewModel getAllEventsViewModel = new GetAllEventsViewModel(events);

        return getAllEventsViewModel.Events.Count is 0
            ? NoContent()
            : Ok(getAllEventsViewModel);
    }


    [HttpPut]
    public async Task<IActionResult> UpdateEvent ([FromBody] UpdateEventRequestViewModel updateEventRequestViewModel)
    {
        if(updateEventRequestViewModel is null) return BadRequest("updateviewmodel is null");
        Event updatedEvent = new Event(
            name: updateEventRequestViewModel.Name,
            date: updateEventRequestViewModel.Date,
            location: updateEventRequestViewModel.Location,
            eventId: updateEventRequestViewModel.UpdateEventId);
        
        await _eventRepository.UpdateEvent(updatedEvent);

        UpdateEventResponseViewModel updateEventResponseViewModel = new UpdateEventResponseViewModel(
            updatedEvent.Name,
            updatedEvent.Date,
            updatedEvent.Location,
            updatedEvent.EventId);
        return Ok(updateEventResponseViewModel);
    }


    [HttpDelete]
    public async Task<IActionResult> DeleteEvent(int eventId)
    {
        await _eventRepository.DeleteEvent(eventId);
        return Ok();        
    }
}
