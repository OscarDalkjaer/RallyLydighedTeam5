namespace API.ViewModels
{
    public class AddEventResponseViewModel
    {
        public string Name { get; }
        public DateTime Date { get; }
        public string Location { get; }
        public int? EventId {  get; }

        public AddEventResponseViewModel(string name, DateTime date, string location, int? eventId)
        {
            Name = name;
            Date = date;
            Location = location;
            EventId = eventId;
        }
    }
}
