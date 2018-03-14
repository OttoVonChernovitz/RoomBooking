using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RoomBookin.Models
{
    public class ReservationContext : DbContext
    {
        public ReservationContext() :base("ReservationContext")
        {

        }
        public DbSet<Room> Room { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
    }
}