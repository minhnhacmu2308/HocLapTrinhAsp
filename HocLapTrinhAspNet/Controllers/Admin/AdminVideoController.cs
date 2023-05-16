using HocLapTrinhAspNet.Models;
using HocLapTrinhAspNet.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocLapTrinhAspNet.Controllers.Admin
{
    public class AdminVideoController : Controller
    {
        CourseRepository ctypeDao = new CourseRepository();
        CourseVideoRepository typeDao = new CourseVideoRepository();
        // GET: AdminBranch
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            ViewBag.List = typeDao.GetAll();
            ViewBag.listType = ctypeDao.GetAll();
            return View();
        }
        public ActionResult Add(CourseVideo obj)
        {
            typeDao.AddCourseVideo(obj);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Update(CourseVideo obj)
        {
            typeDao.UpdateCourseVideo(obj);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Delete(CourseVideo obj)
        {
            typeDao.DeleteCourseVideo(obj.CourseVideoId);
            return RedirectToAction("Index", new { msg = "1" });
        }
    }
}