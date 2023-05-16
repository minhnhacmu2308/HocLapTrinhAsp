using HocLapTrinhAspNet.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocLapTrinhAspNet.Controllers
{
    public class NewsController : Controller
    {
        NewsRepository _newRepository = new NewsRepository();
        // GET: News
        public ActionResult Index(int page)
        {
            if (page == 0)
            {
                page = 1;
            }
            ViewBag.courses = _newRepository.Gets(page, 6);
            ViewBag.tag = page;
            ViewBag.pageSize = _newRepository.getNumber();
            return View();
        }
        public ActionResult Detail(int id)
        {
            ViewBag.course = _newRepository.GetNewsById(id);
            return View();
        }
    }
}