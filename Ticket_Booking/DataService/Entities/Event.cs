using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataService.Entities
{
    public class Event
    {
        [Key]
        public int event_id { get; set; }
        public string event_name { get; set; }
        public DateTime event_date { get; set; }
        public DateTime event_time { get; set; }

        public int venue_id { get; set; }
        [ForeignKey("venue_id")]
        public Venue Venue { get; set; }
        public int available_seats { get; set; }
        public string artist_name { get; set; }
        public string description { get; set; }
        public String approval_status { get; set; }
        public string image { get; set; }
        public int ticketprice { get; set; }

    }
}
