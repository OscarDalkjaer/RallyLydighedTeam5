using Core.Domain.Entities;

namespace API.ViewModels;

public class UpdateEventResponse
{
    public required string Name { get; init; }
    public required DateTime Date { get; init; }
    public required string Location { get; init; }
    public required int? UpdateEventId { get; init; }

    public static UpdateEventResponse ConvertFromEvent(Event @event)
    {
        return new UpdateEventResponse
        {
            UpdateEventId = @event.EventId,
            Name = @event.Name,
            Date = @event.Date,
            Location = @event.Location,
        };
    }
}
