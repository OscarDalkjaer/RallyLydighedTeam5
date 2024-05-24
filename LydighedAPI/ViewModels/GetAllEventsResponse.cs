using Core.Domain.Entities;

namespace API.ViewModels;

public class GetAllEventsResponse
{
    public required List<GetEventResponse> Events { get; init; }

    public static GetAllEventsResponse ConvertFromEvents(IEnumerable<Event> events)
    {
        return new GetAllEventsResponse
        {
            Events = events
                .Select(@event => GetEventResponse.ConvertFromEvent(@event))
                .ToList()
        };
    }
}
