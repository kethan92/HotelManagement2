using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagerReponsity_MVC.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string groupid { get; set; }
    }
}