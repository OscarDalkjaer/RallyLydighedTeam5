using BusinessLogic.Models;

namespace BusinessLogic.Services
{
    public interface IEventRepository
    {
        Task AddEvent(Event @event); //event is a keyword in c#, therefore @-prefix is needed
        Task<Event?> GetEvent(int id);
        Task<IEnumerable<Event>> GetAllEvents();
        Task UpdateEvent(Event updatedEvent);
        Task DeleteEvent(int eventId);
    }
}
