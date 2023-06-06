using HocLapTrinhAspNet.Models;
using HocLapTrinhAspNet.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocLapTrinhAspNet.Controllers.Admin
{
    public class AdminAuthenticationController : Controller
    {
        UserRepository _userRepository = new UserRepository();

        // GET: AdminAuthenticaion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            User user = new User()
            {
                Email = form["email"],
                Password = form["password"]
            };
            User login = _userRepository.CheckLogin(user);
            if (login != null && login.RoleId == 1)
            {
                var userinfor = _userRepository.getUserByEmail(user.Email);
                Session.Add("ADMIN", userinfor);
                return RedirectToAction("Index", "AdminHome");
            }
            else
            {
                ViewBag.mess = "Thông tin tài khoản hoặc mật khẩu không chính xác";
                return View("Login");
            }

        }
        public ActionResult Logout()
        {
            Session.Remove("ADMIN");
            return Redirect("/AdminHome/Index");
        }
    }
}