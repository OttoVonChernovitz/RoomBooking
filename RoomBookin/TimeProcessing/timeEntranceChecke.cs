using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RoomBookin.Models;

namespace RoomBookin.TimeProcessing
{
    public class timeEntranceChecke
    {

        public bool timeEnteringCheck(ref string errorMessageText, Reservation Reserve)
        {
            bool correctFormat = true;

            if(DateTime.Compare(Reserve.DateTimeOfStart, Reserve.DateTimeOfFinish)>=0)
            {
                correctFormat = false;
                errorMessageText = "Incorrect fomat of time. Time of start can't be later or in same time as time of End";
            }
            return correctFormat;
        }

        public bool startTimeCheck(ref string errorMessageText, Reservation Reserve)
        {
            bool correctFormat = true;

            if (DateTime.Compare(Reserve.DateTimeOfStart, DateTime.Now) < 0)
            {
                correctFormat = false;
                errorMessageText = "Incorrect value of start time. You can't Reserve room in past time";
            }
            return correctFormat;
        }




    }
}