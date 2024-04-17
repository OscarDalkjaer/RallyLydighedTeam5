namespace API.ViewModels
{
    public class AddEventViewModel
    {
        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        public string Location { get; private set; }

        protected AddEventViewModel() { }

        public AddEventViewModel(string name, DateTime date, string location) 
        {
            Name = name;
            Date = date;
            Location = location;
        }
    }
}
