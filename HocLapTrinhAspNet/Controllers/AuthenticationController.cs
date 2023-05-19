using HocLapTrinhAspNet.Models;
using HocLapTrinhAspNet.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocLapTrinhAspNet.Controllers
{
    public class AuthenticationController : Controller
    {
        UserRepository userRepository = new UserRepository();
        // GET: Authentication
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            bool checkEmailExist = userRepository.checkExistEmail(user.Email);
            if (checkEmailExist)
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
            else
            {
                user.RoleId = 2;
                userRepository.AddUser(user);
                return RedirectToAction("Index", new { msg = "1" });
            }

        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            User userInformation = userRepository.CheckLogin(user);
            if (userInformation != null)
            {
                Session.Add("USER", userInformation);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", new { msg = "3" });
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("USER");
            return Redirect("/Home/Index");
        }

        public ActionResult Profiles(string msg)
        {
            ViewBag.Msg = msg;
            User user = (User)Session["USER"];
            ViewBag.User = userRepository.getUserByEmail(user.Email);
            return View();
        }

        [HttpPost]
        public ActionResult UpdateProfile(User user)
        {
            userRepository.UpdateUser(user);
            return RedirectToAction("Profiles", new { msg = "1" });
        }
    }
}