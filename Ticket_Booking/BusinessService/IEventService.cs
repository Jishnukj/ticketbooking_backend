﻿using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessService
{
    public interface IEventService
    {
        List<Event> GetEvents();

    }
}
