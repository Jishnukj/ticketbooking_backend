using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessService.Dto
{
    public class BookingDto
    {
        public int booking_id { get; set; }

        public int user_id { get; set; }


        public int event_id { get; set; }
        public DateTime booking_date { get; set; }
        public int No_of_tickets { get; set; }
        public string username { get; set; }
    }
}
