using HocLapTrinhAspNet.Models;
using HocLapTrinhAspNet.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocLapTrinhAspNet.Controllers.Admin
{
    public class AdminCourseController : Controller
    {

        CourseRepository typeDao = new CourseRepository();
        CourseTypeRepository ctypeDap = new CourseTypeRepository();
        // GET: AdminBranch
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            ViewBag.List = typeDao.GetAll();
            ViewBag.listType = ctypeDap.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Course branch)
        {
            var file = Request.Files["file"];
            string reName = DateTime.Now.Ticks.ToString() + file.FileName;
            file.SaveAs(Server.MapPath("~/Content/images/" + reName));
            branch.Image = reName;
            branch.IsFree = branch.Price == 0;
            typeDao.AddCourse(branch);
            return RedirectToAction("Index", new { msg = "1" });
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Course branch)
        {
            string reName = "";
            var objCourse = typeDao.GetCourseById(branch.CourseId);
            var file = Request.Files["file"];
            if (file.FileName == "")
            {
                reName = objCourse.Image;
            }
            else
            {
                reName = DateTime.Now.Ticks.ToString() + file.FileName;
                file.SaveAs(Server.MapPath("~/Content/images/" + reName));
            }
            branch.Image = reName;
            branch.IsFree = branch.Price == 0;
            typeDao.UpdateCourse(branch);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Delete(Course obj)
        {
            var check = typeDao.GetOrderByCourse(obj.CourseId);
            var check1 = typeDao.GetVideoByCourse(obj.CourseId);
            if (check.Count == 0 && check1.Count == 0)
            {
                typeDao.DeleteCourse(obj.CourseId);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
        }
    }
}