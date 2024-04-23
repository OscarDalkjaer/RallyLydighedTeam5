using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccessDbContext;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Repositories;

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
           
        _courseContext.Events.Add(@event);
           
        _courseContext.SaveChanges();

    }

    public async Task<Event?> GetEvent(int id)
    {
           
        return await _courseContext.Events.FirstOrDefaultAsync(e => e.EventId == id);
            
    }

    public async Task<IEnumerable<Event>> GetAllEvents()
    {
        return await _courseContext.Events.ToListAsync();
    }

    public async Task UpdateEvent(Event updatedEvent)
    {
        Event? eventToUpdate = await _courseContext.Events.FirstOrDefaultAsync(e =>e.EventId == updatedEvent.EventId);
        if (eventToUpdate != null) 
        {
            eventToUpdate.Location = updatedEvent.Location;
            eventToUpdate.Date = updatedEvent.Date;
            eventToUpdate.Name = updatedEvent.Name;
            _courseContext.Update(eventToUpdate);

            await _courseContext.SaveChangesAsync();
        }
    }

    public async Task DeleteEvent(int eventId)
    {
        if (eventId != 0) 
        {
            Event? eventToDelete = await _courseContext.Events.FirstOrDefaultAsync(e =>e.EventId == eventId);   
            if (eventToDelete != null) 
            {
                _courseContext.Remove(eventToDelete);
                await _courseContext.SaveChangesAsync();
            }
        }
    }
}

