namespace Core.Domain.Entities;

public class Event
{
    public int? EventId { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }

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
