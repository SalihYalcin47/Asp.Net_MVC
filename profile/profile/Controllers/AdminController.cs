using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using profile.Models;

namespace profile.Controllers
{
    public class AdminController : Controller
    {
        Skill_Profile_EntityEntities skill = new Skill_Profile_EntityEntities();

        public ActionResult Index()
        {
            viewmodel model = new viewmodel();
            model.dillers = skill.Dillers.ToList();
            model.yeteneklers = skill.Yeteneklers.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(Yetenekler yetenekler)
        {
            skill.Yeteneklers.Add(yetenekler);
            skill.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniDil()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDil(Diller diller)
        {
            skill.Dillers.Add(diller);
            skill.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            var bul = skill.Yeteneklers.Find(id);
            skill.Yeteneklers.Remove(bul);
            skill.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DilSil(int id)
        {
            var bul = skill.Dillers.Find(id);
            skill.Dillers.Remove(bul);
            skill.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekGuncelle(int id)
        {
            var deger = skill.Yeteneklers.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult YetenekGuncelle(Yetenekler y)
        {
            var x = skill.Yeteneklers.Find(y.ID);
            x.YetenekAD = y.YetenekAD;
            x.DEGER = y.DEGER;
            skill.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DilGuncelle(int id)
        {
            var deger = skill.Dillers.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult DilGuncelle(Diller y)
        {
            var x = skill.Dillers.Find(y.ID);
            x.DillAD = y.DillAD;
            x.DEGER = y.DEGER;
            skill.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}