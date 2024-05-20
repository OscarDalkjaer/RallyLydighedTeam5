using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.ViewModels
{
    public class AddEventViewModel
    {
        public string Name { get; }
        public DateTime Date { get; }
        public string Location { get; }

        public AddEventViewModel() : this(null!, DateTime.MinValue, null!) { }


        public AddEventViewModel(string name, DateTime date, string location) 
        {
            Name = name;
            Date = date;
            Location = location;
        }
    }
}
