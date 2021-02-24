using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Repo
{
    public class EventRepo: IEventRepo
    {
        private readonly ApplicationdbContext _dbContext;
        public EventRepo(ApplicationdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Event> getAllEvents()
        {
            return _dbContext.Events.ToList();
        }
        public bool addEvent(Event events)
        {
            _dbContext.Events.Add(events);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
