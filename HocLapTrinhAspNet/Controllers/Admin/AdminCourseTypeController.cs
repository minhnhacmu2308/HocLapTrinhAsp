using HocLapTrinhAspNet.Models;
using HocLapTrinhAspNet.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocLapTrinhAspNet.Controllers.Admin
{
    public class AdminCourseTypeController : Controller
    {

        CourseTypeRepository typeDao = new CourseTypeRepository();
        // GET: AdminBranch
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            ViewBag.List = typeDao.GetAll();
            return View();
        }
        public ActionResult Add(CourseType obj)
        {
            typeDao.AddCourseType(obj);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Update(CourseType obj)
        {
            typeDao.UpdateCourseType(obj);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Delete(CourseType obj)
        {
            var check = typeDao.GetCourseByType(obj.CourseTypeId);
            if (check.Count == 0)
            {
                typeDao.DeleteCourseType(obj.CourseTypeId);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
        }
    }
}