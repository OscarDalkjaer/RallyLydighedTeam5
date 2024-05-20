namespace API.ViewModels
{
    public class GetEventViewModel
    {
        public int? EventId { get; }
        public string Name { get; }
        public DateTimeOffset Date { get; }
        public string Location { get; }


        protected GetEventViewModel() { }


        public GetEventViewModel(int? eventId, string name, DateTimeOffset date, string location) 
        {
            EventId = eventId;
            Name = name;
            Date = date;
            Location = location;
        }
    }
}
