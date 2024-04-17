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
            if (@event == null) 
                throw new ArgumentNullException();
            else Events.Add(@event);
            return Task.CompletedTask;
        }
    }
}
