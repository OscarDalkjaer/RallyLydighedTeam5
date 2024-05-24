using Core.Domain.Entities;

namespace API.ViewModels
{
    public class GetAllEventsViewModel
    {
        public List<GetEventViewModel> Events { get;}
        
        public GetAllEventsViewModel (IEnumerable<Event> events) 
        {
            Events = events
                .Select(e => new GetEventViewModel(e.Name, e.Date, e.Location, e.EventId))
                .ToList();
        }
    }
}
