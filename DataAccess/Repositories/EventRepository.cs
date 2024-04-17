using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccessDbContext;
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
            _courseContext.Events.Add(@event);
        }
    }
}
