using API.ViewModels;
using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
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
        public async Task AddEvent([FromBody] AddEventViewModel addEventViewModel)
        {
            if (addEventViewModel != null) 
            {
                Event @event = new Event(addEventViewModel.Name, addEventViewModel.Date, addEventViewModel.Location); //event is a keyword in c#, therefore @
                await _eventRepository.AddEvent(@event);
                
            }
        }


        [HttpGet("{eventId}", Name = "GetEvent")]
        public async Task<GetEventViewModel> GetEvent(int eventId)
        {
            if(eventId == 0) 
            {
                throw new ArgumentNullException();
            }
            else 
            {
                Event? @event = await _eventRepository.GetEvent(eventId);
                if (@event != null)
                {
                    GetEventViewModel getEventViewModel = new GetEventViewModel(@event.EventId,
                    @event.Name, @event.Date, @event.Location);
                    return await Task.FromResult(getEventViewModel);
                }
            }
            return null;
        }

        [HttpGet(Name ="GetALlEvents")]
        public async Task<IEnumerable<GetEventViewModel>> GetAllEvents()
        {
            IEnumerable<Event> events = await _eventRepository.GetAllEvents();
            IEnumerable<GetEventViewModel> eventsVM = events.Select(e=> new GetEventViewModel(e.EventId, e.Name,
                e.Date, e.Location));
            return await Task.FromResult(eventsVM);
        }
    }
}
