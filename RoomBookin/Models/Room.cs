using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomBookin.Models
{
    public class Room
    {
        // room ID
        public int RoomId { get; set; }
        // number(name) of room
        public int RoomNumber { get; set; }
        // status of room (if there is any more time (more than 30 min) to use it)
        public bool Status { get; set; }
      /* 
        // price of room per ...
        public double Price { get; set; }
        */

    }
}