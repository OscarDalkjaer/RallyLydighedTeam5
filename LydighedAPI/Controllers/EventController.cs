using API.ViewModels;
using BusinessLogic.Models;
using BusinessLogic.Services;
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
    public async Task<IActionResult> AddEvent([FromBody] AddEventViewModel addEventViewModel)
    {
        if (addEventViewModel == null) return BadRequest("ViewModel was null");

        Event @event = new Event(addEventViewModel.Name, addEventViewModel.Date, addEventViewModel.Location); //event is a keyword in c#, therefore @
        await _eventRepository.AddEvent(@event);

        return Ok();       
    }


    [HttpGet("{eventId}", Name = "GetEvent")]
    public async Task<IActionResult> GetEvent(int eventId)
    {
        if (eventId <= 0) return BadRequest("eventId must be larger than 0");
                  
        Event? @event = await _eventRepository.GetEvent(eventId);
            
        if (@event == null) return NotFound($"Event with id {eventId} not found");
        
        GetEventViewModel getEventViewModel = new GetEventViewModel(@event.EventId,
        @event.Name, @event.Date, @event.Location);
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
    public async Task<IActionResult> UpdateEvent ([FromBody] UpdateEventViewModel updateEventViewModel)
    {
        if(updateEventViewModel is null) return BadRequest("updateviewmodel is null");
        Event updatedEvent = new Event(
            name: updateEventViewModel.Name,
            date: updateEventViewModel.Date,
            location: updateEventViewModel.Location,
            eventId: updateEventViewModel.UpdateEventId);
        
        await _eventRepository.UpdateEvent(updatedEvent);

        return Ok();
    }


    [HttpDelete]
    public async Task<IActionResult> DeleteEvent(int eventId)
    {
        await _eventRepository.DeleteEvent(eventId);
        return Ok();        
    }
}
