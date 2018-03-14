using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomBookin.Models
{
    public class Reservation
    {
        // reservation Id
        public int ReservationId { get; set; }
        // id of reserved room
        public int RoomId { get; set; }


        public string Client { get; set; } // name of client // temporarily


        // id of client who made this booking
 //       public int ClientId { get; set; }
        // time when reservation begins
        public DateTime DateTimeOfStart { get; set; }
        // time when reservation ends
        public DateTime DateTimeOfFinish { get; set; }
        // time when order was made
        public DateTime ResevationDateTime { get; set; }


    }
}