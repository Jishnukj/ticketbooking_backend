using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.Entities
{
    public class Venue
    {
        [Key]
        public int venue_id { get; set; }
        public string venue_name { get; set; }
        public int total_seats { get; set; }
        public float ticket_rate { get; set; }

    }
}
