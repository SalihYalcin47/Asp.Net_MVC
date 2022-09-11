using BusinesLayer.Concrete;
using ClassLibrary1.EntityFreamwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp.net_MVC.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content

        ContentManager cm = new ContentManager(new EfContentDall());

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeading( int id)
        {
            var contentvalue = cm.GetListByID(id);
            return View(contentvalue);
        }

        public ActionResult GetAllContent(string p)
        {
            if (string.IsNullOrEmpty(p))
            {
                p = " ";
            }
            var values = cm.GetList(p);
            return View(values);
        }
    }
}