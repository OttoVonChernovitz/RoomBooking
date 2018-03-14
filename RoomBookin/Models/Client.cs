using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomBookin.Models
{
    public class Client
    {
        // client ID
        public int ClientId { get; set; }
        // first name of client
        public string FirstName { get; set; }
        // second mane of client
        public string SecondName { get; set; }
        // Room of booked room by this client
        public int RoomId { get; set; }
        
    }
}