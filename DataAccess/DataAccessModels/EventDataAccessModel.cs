using BusinessLogic.Models;

namespace DataAccess.DataAccessModels
{
    public class EventDataAccessModel
    {
        public string Name { get; set; } // not private setters because of Update-test's use of properties
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int? EventId { get; set; }

        public EventDataAccessModel(Event @event) 
        {
            Name = @event.Name;
            Date = @event.Date;
            Location = @event.Location;
            EventId = @event.EventId;
        }
        
    }
}
