using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagerReponsity.ViewModel
{
    public class RoomStatus
    {
        public int RoomNumber { get; set; }
        public string nameRoom { get; set; }
        public Nullable<int> RoomStatus_id { get; set; }
        public int RoomType_id { get; set; }
        public string status { get; set; }
    }
}