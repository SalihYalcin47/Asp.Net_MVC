using BusinesLayer.Concrete;
using DataAcessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp.net_MVC.Controllers
{
    public class AutHorizationController : Controller
    {
        // GET: AutHorization
        AdminManager adminm = new AdminManager(new EfAdminDall());
        public ActionResult Index()
        {
            var adminvalues = adminm.GetList();
            return View(adminvalues);
        }






        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            adminm.AdminAdd(admin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminvalue = adminm.GetID(id);
            return View(adminvalue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            adminm.AdminUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}