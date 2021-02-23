﻿using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Repo
{
    public interface IEventRepo
    {
        List<Event> getAllEvents();
    }
}
