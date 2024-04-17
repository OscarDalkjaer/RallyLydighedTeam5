﻿using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IEventRepository
    {
        public Task AddEvent(Event @event); //event is a keyword in c#, therefore @-prefix is needed


    }
}
