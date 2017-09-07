using HotelManagerReponsity_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagerReponsity_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
          //  RoomsClient roomsclient = new RoomsClient();
         //   var model = roomsclient.GetAll();
         //   ViewBag.roomsList = model;
            return View();
        }
        [HttpPost]
        public ActionResult Index(room_Type_DescriptionViewModel listroom)
        {
         //   Room_TypeClient roomsType = new Room_TypeClient();
         //   var model = roomsType.searchRoom_Type(listroom);
         //   ViewBag.roomsList = model;
            return View();
        }
    }
}