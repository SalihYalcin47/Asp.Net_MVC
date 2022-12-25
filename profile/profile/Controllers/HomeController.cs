using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using profile.Models;

namespace profile.Controllers
{
    public class HomeController : Controller
    {
        Skill_Profile_EntityEntities profil = new Skill_Profile_EntityEntities();
        
        public ActionResult Index()
        {
            viewmodel model = new viewmodel();
            model.dillers = profil.Dillers.ToList();
             model.yeteneklers = profil.Yeteneklers.ToList();
            return View(model);
        }
    }
}