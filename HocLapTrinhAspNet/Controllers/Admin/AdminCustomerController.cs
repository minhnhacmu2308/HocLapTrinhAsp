using HocLapTrinhAspNet.Models;
using HocLapTrinhAspNet.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocLapTrinhAspNet.Controllers.Admin
{
    public class AdminCustomerController : Controller
    {

        UserRepository userRepository = new UserRepository();
        // GET: AdminCustomer
        public ActionResult Index()
        {
            ViewBag.List = userRepository.GetCusomer();
            return View();
        }
    }
}