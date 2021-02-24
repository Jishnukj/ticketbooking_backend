using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessService.Dto
{
    public class EventDto
    {
        
        public int event_id { get; set; }
        public string event_name { get; set; }
        public DateTime event_date { get; set; }
        public DateTime event_time { get; set; }
        public int venue_id { get; set; }
        public int available_seats { get; set; }
        public string artist_name { get; set; }
        public string description { get; set; }
        public bool approval_status { get; set; }
        public string image { get; set; }

        public string venue_name { get; set; }
        public int total_seats { get; set; }
        public float ticket_rate { get; set; }


    }
}
