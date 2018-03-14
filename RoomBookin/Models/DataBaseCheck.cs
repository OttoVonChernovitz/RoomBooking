using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RoomBookin.Models
{
    public class ReservationTimeChecking
    {
        public bool timeCheck( Reservation Reserve)
        {
            bool orederConfirmed = false;
            using (ReservationContext db = new ReservationContext())
            {
               
                
                var reserves = db.Reservation;

                List<Reservation> ResList = new List<Reservation>();

                foreach (Reservation res in reserves)
                {
                    if (Reserve.RoomId == res.RoomId)
                    {
                        ResList.Add(res);
                    }
                }
                if (ResList.Count == 0)
                {
                    orederConfirmed = true;

                }
                else
                {
                    ResList.Sort((x, y) => DateTime.Compare(x.DateTimeOfStart,y.DateTimeOfStart));


                    for (int i = 0; i < ResList.Count; i++)
                    {

                        int startTimeCompare1 = DateTime.Compare(Reserve.DateTimeOfStart, ResList[i].DateTimeOfStart);
                        int startTimeCompare2 = DateTime.Compare(Reserve.DateTimeOfStart, ResList[i].DateTimeOfFinish);
                        if (startTimeCompare1 != 0)
                        {
                            if (startTimeCompare2 >= 0)
                            {
                                if (i + 1 < ResList.Count)
                                {
                                    int endTimeCompare = DateTime.Compare(Reserve.DateTimeOfFinish, ResList[i + 1].DateTimeOfStart);
                                    if (endTimeCompare <= 0)
                                        orederConfirmed = true;
                                }
                                else
                                {
                                    if (i + 1 == ResList.Count)
                                    {
                                        orederConfirmed = true;
                                    }

                                }
                            }
                            else if (startTimeCompare1 < 0)
                            {
                                int endTimeCompare = DateTime.Compare(Reserve.DateTimeOfFinish, ResList[i].DateTimeOfStart);
                                if (endTimeCompare <= 0)
                                    orederConfirmed = true;

                            }
                        }
                        else
                        {
                            orederConfirmed = false;   
                            break;
                        }
                    }

                }
            }
            
         return orederConfirmed;

        }

    }
}