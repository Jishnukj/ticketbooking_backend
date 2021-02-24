using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Repo
{
    public interface IEventRepo
    {
        List<Event> getAllEvents();
        bool addEvent(Event events);
        bool appoveEvent(int event_id, string appove);
    }
}
