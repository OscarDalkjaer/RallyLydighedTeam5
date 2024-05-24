using Core.Domain.Entities;

namespace API.ViewModels
{
    public class GetEventResponse
    {
        public required int? EventId { get; init; }
        public required string Name { get; init; }
        public required DateTime Date { get; init; }
        public required string Location { get; init; }

        public static GetEventResponse ConvertFromEvent(Event @event)
        {
            return new GetEventResponse
            {
                EventId = @event.EventId,
                Name = @event.Name,
                Date = @event.Date,
                Location = @event.Location
            };
        }
    }
}
