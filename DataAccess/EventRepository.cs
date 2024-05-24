﻿using Core.Domain.Entities;
using Core.Domain.Services;
using DataAccess.DataAccessModels;
using DataAccessDbContext;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure;

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
        EventDataAccessModel eventDataAccessModel = new EventDataAccessModel(@event.Name, @event.Date, @event.Location, @event.EventId);
        _courseContext.EventDataAccessModels.Add(eventDataAccessModel);

        _courseContext.SaveChanges();
    }

    public async Task<Event?> GetEvent(int id)
    {
        EventDataAccessModel? dataAccessModel = await _courseContext.EventDataAccessModels
            .FirstOrDefaultAsync(e => e.EventDataAccessModelId == id);
        Event @event = FromAccessModelToEvent(dataAccessModel);
        return @event;
    }

    public async Task<IEnumerable<Event>> GetAllEvents()
    {
        List<EventDataAccessModel>? dataAccessModels = await _courseContext
            .EventDataAccessModels.ToListAsync();
        List<Event> events = dataAccessModels.Select(x =>
        new Event(x.Name, x.Date, x.Location, x.EventDataAccessModelId)).ToList();
        return events;
    }

    public async Task UpdateEvent(Event updatedEvent)
    {
        EventDataAccessModel? dataAccessModelToUpdate = await _courseContext
            .EventDataAccessModels.FirstOrDefaultAsync(e => e.EventDataAccessModelId == updatedEvent.EventId);
        if (dataAccessModelToUpdate != null)
        {
            dataAccessModelToUpdate.Location = updatedEvent.Location;
            dataAccessModelToUpdate.Date = updatedEvent.Date;
            dataAccessModelToUpdate.Name = updatedEvent.Name;
            _courseContext.Update(dataAccessModelToUpdate);

            await _courseContext.SaveChangesAsync();
        }
    }

    public async Task DeleteEvent(int eventId)
    {
        if (eventId != 0)
        {
            EventDataAccessModel? eventDataAccessModelToDelete = await _courseContext.EventDataAccessModels.FirstOrDefaultAsync(e =>
                e.EventDataAccessModelId == eventId);
            if (eventDataAccessModelToDelete != null)
            {
                _courseContext.Remove(eventDataAccessModelToDelete);
                await _courseContext.SaveChangesAsync();
            }
        }
    }

    public Event FromAccessModelToEvent(EventDataAccessModel eventDataAccessModel)
    {
        return new Event(
            eventDataAccessModel.Name,
            eventDataAccessModel.Date,
            eventDataAccessModel.Location,
            eventDataAccessModel.EventDataAccessModelId
            );
    }
}
