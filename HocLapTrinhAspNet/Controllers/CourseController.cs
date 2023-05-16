using HocLapTrinhAspNet.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocLapTrinhAspNet.Controllers
{
    public class CourseController : Controller
    {
        UserRepository _userRepository = new UserRepository();
        CourseRepository courseRepository = new CourseRepository();
        CourseTypeRepository courseTypeRepository = new CourseTypeRepository();
        // GET: Course
        public ActionResult Index(string isFree,int page)
        {
            if (page == 0)
            {
                page = 1;
            }
            ViewBag.courses = courseRepository.GetCourseByIsFree(bool.Parse(isFree), page, 6);
            ViewBag.tag = page;
            ViewBag.pageSize = courseRepository.getNumberByIsFree(bool.Parse(isFree));
            ViewBag.isFree = isFree;
            return View();
        }

        public ActionResult Detail(int id)
        {
            ViewBag.course = courseRepository.GetCourseById(id);
            return View();
        }

        public ActionResult CourseAll(int page)
        {
            if (page == 0)
            {
                page = 1;
            }
            ViewBag.courses = courseRepository.Gets(page, 6);
            ViewBag.tag = page;
            ViewBag.pageSize = courseRepository.getNumber();
            return View();
        }

        public ActionResult GetCourseByType(int courseTypeId, int page)
        {
            if (page == 0)
            {
                page = 1;
            }
            var list = courseRepository.GetCourseByType(courseTypeId, page, 6);
            var obj = courseTypeRepository.GetCourseTypeById(courseTypeId);
            ViewBag.courses = list;
            ViewBag.tag = page;
            ViewBag.pageSize = courseRepository.getNumberByType(courseTypeId);
            ViewBag.Type = obj;
            return View();
        }
    }
}