using Core.Domain.Entities;

namespace API.ViewModels;

public class AddEventRequest
{
    public required string Name { get; init; }
    public required DateTime Date { get; init; }
    public required string Location { get; init; }

    public Event ConvertToEvent(){
        return new Event(Name, Date, Location);
    }
}
