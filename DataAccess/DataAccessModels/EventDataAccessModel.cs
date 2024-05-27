using Core.Domain.Entities;

namespace DataAccess.DataAccessModels;

public class EventDataAccessModel
{
    public string Name { get;  set; } // not private setters because of Update-test's use of properties
    public DateTime Date { get;  set; }
    public string Location { get;  set; }
    public int? EventDataAccessModelId { get; set; }

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
