namespace API.ViewModels
{
    public class AddEventRequestViewModel
    {
        public string Name { get; }
        public DateTime Date { get; }
        public string Location { get; }

        public AddEventRequestViewModel(string name, DateTime date, string location) 
        {
            Name = name;
            Date = date;
            Location = location;
        }
    }
}
