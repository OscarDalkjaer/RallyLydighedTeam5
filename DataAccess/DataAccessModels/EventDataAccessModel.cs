using Core.Domain.Entities;

namespace DataAccess.DataAccessModels;

public class EventDataAccessModel
{
    public string Name { get; protected set; } // not private setters because of Update-test's use of properties
    public DateTime Date { get; protected set; }
    public string Location { get; protected set; }
    public int? EventDataAccessModelId { get; protected set; }

    protected EventDataAccessModel()
    {
    }

    public EventDataAccessModel(int? eventDataAccessModelId, string name, DateTime date, string location)
    {
        EventDataAccessModelId = eventDataAccessModelId;
        Name = name;
        Date = date;
        Location = location;
    }

    public static EventDataAccessModel ConvertFromEvent(Event @event)
    {
        return new EventDataAccessModel
        {
            EventDataAccessModelId = @event.EventId,
            Name = @event.Name,
            Date = @event.Date,
            Location = @event.Location
        };
    }

    public Event ConvertToEvent()
    {
        return new Event(Name, Date, Location, EventDataAccessModelId);
    }
}
