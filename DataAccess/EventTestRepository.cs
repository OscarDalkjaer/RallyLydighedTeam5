using BusinessLogic.Models;
using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class EventTestRepository : IEventRepository
    {
        public List<Event> TestEvents { get; } = new List<Event>();

        public async Task AddEvent(Event @event)
        {
            @event.EventId = TestEvents.Count() + 1;
            TestEvents.Add(@event);

            await Task.CompletedTask;
        }

        public async Task<Event?> GetEvent(int id)
        {
            Event? @event = TestEvents.SingleOrDefault(e => e.EventId == id);
            return await Task.FromResult(@event);
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            IEnumerable<Event> events = TestEvents;
            return await Task.FromResult(events);
        }

        public async Task UpdateEvent(Event updatedEvent)
        {
            Event? eventToUpdate = TestEvents.SingleOrDefault(e => e.EventId == updatedEvent.EventId);
            if (eventToUpdate != null)
            {
                eventToUpdate.Name = updatedEvent.Name;
                eventToUpdate.Location = updatedEvent.Location;
                eventToUpdate.Date = updatedEvent.Date;
            }

            await Task.CompletedTask;
        }

        public async Task DeleteEvent(int eventId)
        {
            Event? eventToDelete = TestEvents.SingleOrDefault(e => e.EventId == eventId);
            if (eventToDelete != null)
            {
                TestEvents.Remove(eventToDelete);
            }

            await Task.CompletedTask;
        }
    }
}
