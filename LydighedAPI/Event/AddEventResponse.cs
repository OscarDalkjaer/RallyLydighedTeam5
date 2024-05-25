using Core.Domain.Entities;

namespace API.ViewModels;

public class AddEventResponse
{
    public required string Name { get; init; }
    public required DateTime Date { get; init; }
    public required string Location { get; init; }
    public required int? EventId { get; init; }

    public static AddEventResponse ConvertToAddEventResponse(Event @event)
    {
        return new AddEventResponse
        {
            Name = @event.Name,
            Date = @event.Date,
            Location = @event.Location,
            EventId = @event.EventId
        };
    }
}
