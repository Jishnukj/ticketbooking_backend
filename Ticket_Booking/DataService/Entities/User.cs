using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.Entities
{
    public class User
    { 
        [Key]
        public int user_id { get; set; }
        public string user_type{ get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string band_name { get; set; }
    }
}
