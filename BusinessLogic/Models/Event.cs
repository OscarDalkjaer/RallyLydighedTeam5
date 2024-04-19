using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class Event
    {
        protected Event() { }
        public Event(string name, DateTime date, string location, int? eventId=null)
        {
            Name = name ;
            Date = date;
            Location = location;
            EventId = eventId;
        }

        public string Name { get; set; } // not private setters because of Update-test's use of properties
        public DateTime Date { get;  set; }
        public string Location { get; set; }
        public int? EventId { get; set; }
    }
}
