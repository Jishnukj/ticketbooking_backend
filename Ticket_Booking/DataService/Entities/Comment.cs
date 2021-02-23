using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataService.Entities
{
    public class Comment
    {
        [Key]
        public int comment_id { get; set; }
      
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public User User { get; set; }

        
        public int event_id { get; set; }
        [ForeignKey("event_id")]
        public Event Event { get; set; }
        public string comment { get; set; }
        public string reply { get; set; }
    }
}
