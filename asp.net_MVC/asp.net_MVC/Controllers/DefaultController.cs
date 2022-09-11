using BusinesLayer.Concrete;
using ClassLibrary1.EntityFreamwork;
using DataAccesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp.net_MVC.Controllers
{
    [AllowAnonymous]

    public class DefaultController : Controller
    {
        // GET: Default

        HeadingManager hm = new HeadingManager(new EfHeadingDall());
        ContentManager cm = new ContentManager(new EfContentDall());

        public ActionResult Headings()
        {
            var headinglist = hm.GetList();
            return View(headinglist);
        }
        public PartialViewResult Index(int id = 4)
        {
            var contentlist = cm.GetListByID(id);
            if (contentlist.Count == 0)
            {
                ViewBag.message = "Henuz Yorum Yapan Yok";
                return PartialView(contentlist);
            }
            return PartialView(contentlist);
        }
    }
}