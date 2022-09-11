using BusinesLayer.Concrete;
using BusinesLayer.ValidationRules;
using ClassLibrary1.EntityFreamwork;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;   // verilerin sayfayı kaplayacak adedini belirlemek için kullanılır
using PagedList.Mvc;  // verilerin sayfayı kaplayacak adedini belirlemek için kullanılır
using System.Web.Mvc;
using FluentValidation.Results;
using System.IO;
using System.Web.Security;

namespace asp.net_MVC.Controllers
{
    [AllowAnonymous]

    public class LoginController : Controller
    {
        // GET: Login
        WriterLoginManager wlm = new WriterLoginManager(new EfWriterDall());
        WriterManager wm = new WriterManager(new EfWriterDall());
        Context c = new Context();



            [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            Context c = new Context();

            var admininfo = c.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.Adminpassword == admin.Adminpassword);

            if (admininfo != null)
            {
                FormsAuthentication.SetAuthCookie(admininfo.AdminUserName, false);         // yetkilendirme
                    Session["AdminUserName"] = admininfo.AdminUserName;
              return  RedirectToAction("Index", "AdminCategory");
            }
            else
            {
               return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            var Writeruserininfo = wlm.GetWriter(writer.WriterMail, writer.WriterPassword);

            if (Writeruserininfo != null)
            {
                FormsAuthentication.SetAuthCookie(Writeruserininfo.WriterMail, false);         // yetkilendirme
                Session["WriterMail"] = Writeruserininfo.WriterMail;
                return RedirectToAction("AllHeading", "WriterPanel");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz Kullanıcı Girişi";
                return View();
            }
        }

        [HttpGet]
        public ActionResult WriterRecord()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterRecord(Writer writer)
        {
            var Writeruserininfo = wlm.GetWriterRecord(writer.WriterMail);
            if (Writeruserininfo != null)
            {
                FormsAuthentication.SetAuthCookie(Writeruserininfo.WriterMail, false);         // yetkilendirme
                Session["WriterMail"] = Writeruserininfo.WriterMail;
                ViewBag.Mesaj2 = "Bu mail Hesabına Ait Hesap Zaten Var";
                return View();
            }
            else if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string fileextension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + filename + fileextension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                writer.WriterImage = "/Image/" + filename + fileextension;

                c.Writers.Add(writer);
                c.SaveChanges();
                return RedirectToAction("WriterLogin", "Login");
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("HomePage", "Home");
        }
    }
}