namespace API.ViewModels
{
    public class GetEventViewModel
    {
        public int? EventId { get; }
        public string Name { get; }
        public DateTime Date { get; }
        public string Location { get; }

        protected GetEventViewModel() { }

        public GetEventViewModel(string name, DateTime date, string location, int? eventId ) 
        {
            EventId = eventId;
            Name = name;
            Date = date;
            Location = location;
        }

        
    }
}
