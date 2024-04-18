using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccessDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EventRepository : IEventRepository
    {
        protected EventRepository() { }

        private readonly CourseContext _courseContext;
        public EventRepository(CourseContext courseContext) 
        {
            _courseContext = courseContext;
        }

        public async Task AddEvent(Event @event)
        {
            if (@event != null)
            {
                _courseContext.Events.Add(@event);
            }
            _courseContext.SaveChanges();

        }

        public async Task<Event?> GetEvent(int id)
        {
           if(id == 0) 
            {
                throw new ArgumentException();
            }
            else 
            {
                return _courseContext.Events.FirstOrDefault(e => e.EventId == id);
            }
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _courseContext.Events.ToListAsync();
        }

        public async Task UpdateEvent(Event updatedEvent)
        {
            Event? eventToUpdate = _courseContext.Events.First(e =>e.EventId == updatedEvent.EventId);
            if (eventToUpdate != null) 
            {
                eventToUpdate.Location = updatedEvent.Location;
                eventToUpdate.Date = updatedEvent.Date;
                eventToUpdate.Name = updatedEvent.Name;
                _courseContext.Update(eventToUpdate);
                await _courseContext.SaveChangesAsync();
            }
        }
    }
}
