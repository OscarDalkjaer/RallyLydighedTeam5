namespace API.ViewModels
{
    public class UpdateEventViewModel
    {        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        public string Location { get; private set; }
        public int UpdateEventId { get; }

        protected UpdateEventViewModel() { }

        public UpdateEventViewModel(string name, DateTime date, string location, int updateEventId)
        {
            Name = name;
            Date = date;
            Location = location;
            UpdateEventId = updateEventId;
        }
    }
}
