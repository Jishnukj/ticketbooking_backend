using BusinessService.Dto;
using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessService
{
    public interface IEventService
    {
        List<EventDto> GetEvents();
        List<EventDto> GetUpComingEvents();
        bool addEvent(Event events);
        List<EventDto> GetEventById(int id);
        List<EventDto> GetEventByDate(DateTime date);
        bool appoveEvent(int event_id, string approve);
        List<EventDto> GetApporedEvents();

    }
}
