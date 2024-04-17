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
        public Event(string name, DateOnly dateOnly, string location, int? eventId=null)
        {
            Name = name ;
            DateOnly = dateOnly;
            Location = location;
            EventId = eventId;
        }

        public string Name { get; private set; }
        public DateOnly DateOnly { get; private set; }
        public string Location { get; private set; }
        public int? EventId { get; private set; }
    }
}
