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
        public bool appoveEvent(int event_id, bool appove)
        {
            Event eventnew = _dbContext.Events.Where(x => x.event_id == event_id).FirstOrDefault();
            if (eventnew != null)
            {
                eventnew.approval_status = appove;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
