namespace Core.Domain.Entities;

public class Event
{
    public int? EventId { get; protected set; }
    public string Name { get; protected set; }
    public DateTime Date { get; protected set; }
    public string Location { get; protected set; }

    public Event(string name, DateTime date, string location, int? eventId = null)
    {
        Name = name;
        Date = date;
        Location = location;
        EventId = eventId;
    }

    public Event(int? eventId)
    {
        EventId = eventId;
    }
}
