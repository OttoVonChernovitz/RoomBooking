using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RoomBookin.Models
{
    public class RoomDbInitializer : DropCreateDatabaseIfModelChanges<ReservationContext>
    {
        protected override void Seed(ReservationContext db)
        {
            {
                gt1:
                if (db.Database.Connection == null)
                {
                    db.Room.Add(new Room { RoomId = 1, RoomNumber = 605, Status = true });
                    db.Room.Add(new Room { RoomId = 2, RoomNumber = 606, Status = true });
                    db.Room.Add(new Room { RoomId = 3, RoomNumber = 607, Status = false });

                    base.Seed(db);
                }
                else
                {
                    db.Database.Connection.Close();
                    goto gt1;
                }

                


                db.Database.Connection.Close();
            }
        }
            
    }
}