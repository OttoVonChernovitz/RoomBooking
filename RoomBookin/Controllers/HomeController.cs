using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RoomBookin.Models;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        ReservationContext db = new ReservationContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            IEnumerable<Room> rooms = db.Room;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Room = rooms;
            // возвращаем представление
            return View();
        }

         [HttpGet]
        public ActionResult Reserve(int id)
        {

            ViewBag.RoomId = id;
            return View();
        }
       [HttpPost]
        public string Reserve(Reservation Reserve)
        {
            

            Reserve.ResevationDateTime = DateTime.Now;

            ReservationTimeChecking dbc = new ReservationTimeChecking();




            if (dbc.timeCheck(Reserve))
            {
                // добавляем информацию о покупке в базу данных
                db.Reservation.Add(Reserve);
                // сохраняем в бд все изменения
                db.SaveChanges();
                db.Dispose();
                return "Thanks," + Reserve.Client + ", for Reservating!";
            }
            else
            {
                return "Soory," + Reserve.Client + ", but it's impossible";              
            }



        }
    }
}