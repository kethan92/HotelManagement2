using HotelManagerReponsity_MVC.Models;
using HotelManagerReponsity_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagerReponsity_MVC.Controllers
{
    public class LoginAdminController : Controller
    {
        // GET: LoginAdmin
        public ActionResult Index()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(LoginUser user)
        {
            if (ModelState.IsValid)
            {

                var result = new UserClient().checkUser(user);

                if (result != null)
                {
                  //  User _user = new HotelManager_MVC.Models.User();
                 //   _user.id = result.id;
                  //  _user.username = result.username;
                  //  _user.password = result.password;
                  //  _user.groupid = result.groupid;
                    //
                    // Session.Add(HotelManager_MVC.Const.ValueConst.ADMIN_SESSION, _user);
                    // trả về Action Index của controller HomeController
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Sai tên tài khoản hoặc mật khẩu!");
                    return View("Index");
                }
            }
            return View("Index");

        }
    }
}