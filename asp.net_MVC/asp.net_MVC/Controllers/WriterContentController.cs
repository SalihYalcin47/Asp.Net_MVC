using BusinesLayer.Concrete;
using ClassLibrary1.EntityFreamwork;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp.net_MVC.Controllers
{
    public class WriterContentController : Controller
    {
        // GET: WriterContent
        ContentManager cm = new ContentManager(new EfContentDall());
        Context c = new Context();
        public ActionResult MyContent( string user)
        {
            user = (string)Session["WriterMail"];
            var userinfo = c.Writers.Where(x => x.WriterMail == user).Select( y => y.WriterID).FirstOrDefault();
            var usercontent = c.Writers.Where(x => x.WriterMail == user).Select( y => y.Contents).FirstOrDefault();
            if (usercontent.Count != 0)
            {
                var contentvalue = cm.GetListByWriter(userinfo);
                return View(contentvalue);
            }
            ViewBag.mesage = "Henüz Hiçbir Yazı Yazmadınız";
            var contentvalue2 = cm.GetListByWriter(userinfo);
            return View(contentvalue2);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;

            return View();  
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterMail"];
            var userinfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterID = userinfo;
            content.ContentStatus = true;
            cm.ContentAdd(content);
            return RedirectToAction("MyContent");
        }
    }
}