namespace DataAccess.DataAccessModels;

public class EventDataAccessModel
{
    public string Name { get; set; } // not private setters because of Update-test's use of properties
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public int? EventDataAccessModelId { get; set; }

    public EventDataAccessModel(string name, DateTime date, string location, int? eventDataAccessModelId)
    {
        Name = name;
        Date = date;
        Location = location;
        EventDataAccessModelId = eventDataAccessModelId;
    }
}
