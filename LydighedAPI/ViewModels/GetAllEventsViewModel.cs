﻿using BusinessLogic.Models;

namespace API.ViewModels
{
    public class GetAllEventsViewModel
    {
        public List<GetEventViewModel> Events { get;}
        
        public GetAllEventsViewModel (IEnumerable<Event> events) 
        {
            Events = events
                .Select(e => new GetEventViewModel(e.EventId, e.Name, e.Date, e.Location))
                .ToList();
        }



    }
}