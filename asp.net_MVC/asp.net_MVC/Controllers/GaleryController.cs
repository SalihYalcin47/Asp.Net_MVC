using BusinesLayer.Concrete;
using DataAcessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp.net_MVC.Controllers
{
    public class GaleryController : Controller
    {
        // GET: Galery
        ImageFileManager ifm = new ImageFileManager(new EfImageFileDall());

        public ActionResult Index()
        {
            var file = ifm.GetList();
            return View(file);
        }
    }
}