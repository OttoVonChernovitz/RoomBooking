using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RoomBookin.Models;

namespace RoomBookin.TimeProcessing
{
    public class RoomStateUpdator
    {


        public bool foolTimeCheck(int id)
        {
            bool roomState = true;
            TimeSpan workingDayLength = new TimeSpan(8, 30, 0);
            TimeSpan BookedTime = new TimeSpan(0, 0, 0);

            using (ReservationContext db = new ReservationContext())
            {
                var reserves = db.Reservation;

                foreach (Reservation res in reserves)
                {
                    if (id == res.RoomId)
                    {
                        BookedTime += res.DateTimeOfFinish.Subtract(res.DateTimeOfStart);
                    }
                }
                if(BookedTime>workingDayLength)
                {
                    roomState = false;
                }
            } 
                return roomState;
        }


        public bool reservationTimeBorders(Reservation Reserve)
        {
            bool reservationPossibility = true;

            TimeSpan workingDayStart = new TimeSpan(10, 0, 0);
            TimeSpan workingDayEnd = new TimeSpan(19, 0, 0);

            TimeSpan reservationStart = new TimeSpan(Reserve.DateTimeOfStart.Hour, Reserve.DateTimeOfStart.Minute, Reserve.DateTimeOfStart.Second);
            TimeSpan reservationFinish = new TimeSpan(Reserve.DateTimeOfFinish.Hour, Reserve.DateTimeOfFinish.Minute, Reserve.DateTimeOfFinish.Second);

            if (TimeSpan.Compare(workingDayStart, reservationStart) > 0)
            {
                reservationPossibility = false;
            }
            if (TimeSpan.Compare(workingDayEnd, reservationStart) <= 0)
            {
                reservationPossibility = false;
            }
            if (TimeSpan.Compare(workingDayEnd, reservationFinish) < 0)
            {
                reservationPossibility = false;
            }

            return reservationPossibility;
        }



    }
}