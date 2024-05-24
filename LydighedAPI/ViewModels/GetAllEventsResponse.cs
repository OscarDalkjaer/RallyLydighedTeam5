using Core.Domain.Entities;

namespace API.ViewModels
{
    public class GetAllEventsResponse
    {
        public required List<GetEventViewModel> Events { get; init; }

        public static GetAllEventsResponse ConvertFromEvents(IEnumerable<Event> events)
        {
            return new GetAllEventsResponse
            {
                Events = events
                    .Select(e => new GetEventViewModel(e.Name, e.Date, e.Location, e.EventId))
                    .ToList()
            };
        }
    }
}
