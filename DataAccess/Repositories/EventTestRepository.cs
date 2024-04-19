using BusinessLogic.Models;
using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EventTestRepository : IEventRepository
    {
        public List<Event> Events = new List<Event>();

        public Task AddEvent(Event @event)
        {
            int id = Events.Count() + 1;
            if (@event == null)
            {
                throw new ArgumentNullException();
            }

            else
            {
                @event.EventId = id;
                Events.Add(@event);
            }
            return Task.CompletedTask;
        }

       public async Task<Event?> GetEvent(int id)
        {
            Event? @event = Events.FirstOrDefault(e => e.EventId == id);
            return await Task.FromResult(@event);
        }

        public Task<IEnumerable<Event>> GetAllEvents()
        {
            IEnumerable<Event> events = Events;
            return Task.FromResult(events);
        }

        public async Task UpdateEvent(Event updatedEvent)
        {
            Event eventToUpdate = Events.First(e => e.EventId ==  updatedEvent.EventId);  
            eventToUpdate.Name = updatedEvent.Name;
            eventToUpdate.Location = updatedEvent.Location;
            eventToUpdate.Date = updatedEvent.Date;
            await Task.CompletedTask;
        }

        public async Task DeleteEvent(int eventId)
        {
            Event eventToDelete = Events.FirstOrDefault(e =>e.EventId == eventId);
            Events.Remove(eventToDelete);
            await Task.CompletedTask;
        }
    }
}
