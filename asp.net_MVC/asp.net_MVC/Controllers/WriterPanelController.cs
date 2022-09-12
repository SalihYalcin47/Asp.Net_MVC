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

namespace asp.net_MVC.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager hm = new HeadingManager(new EfHeadingDall());
        CategoryManager cm = new CategoryManager(new EfCategoryDall());
        MessageValidator mv = new MessageValidator();
        WriterManager wm = new WriterManager(new EfWriterDall());
        Context c = new Context();


        public ActionResult MyProfile(string writerId)
        {
            writerId = (string)Session["WriterMail"];
            var WriterInfo = c.Writers.Where(x => x.WriterMail == writerId).Select(y => y.WriterID).FirstOrDefault();

            ViewBag.name = c.Writers.Where(x => x.WriterMail == writerId).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.surname = c.Writers.Where(x => x.WriterMail == writerId).Select(y => y.WriterSurname).FirstOrDefault();
            ViewBag.img = c.Writers.Where(x => x.WriterMail == writerId).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.about = c.Writers.Where(x => x.WriterMail == writerId).Select(y => y.WriterAbout).FirstOrDefault();
            ViewBag.e = c.Writers.Where(x => x.WriterMail == writerId).Select(y => y.WriterTitle).FirstOrDefault();
            ViewBag.mail = c.Writers.Where(x => x.WriterMail == writerId).Select(y => y.WriterMail).FirstOrDefault();
            var values = wm.GetId(WriterInfo);
            
            return View(values);
        }


        public ActionResult _WriterLayout()
        {
            ViewBag.d = 2;
            return View();
        }

        public PartialViewResult panel(string writerId)
        {
              writerId = (string)Session["WriterMail"];
               var WriterInfo = c.Writers.Where(x => x.WriterMail == writerId).Select(y => y.WriterID).FirstOrDefault();

              ViewBag.name = c.Writers.Where(x => x.WriterMail == writerId).Select(y => y.WriterName).FirstOrDefault();
               ViewBag.surname = c.Writers.Where(x => x.WriterMail == writerId).Select(y => y.WriterSurname).FirstOrDefault();
               ViewBag.image = c.Writers.Where(x => x.WriterMail == writerId).Select(y => y.WriterImage).FirstOrDefault();
            return PartialView();
        }

        [HttpGet]
        public ActionResult WriterProfil(int id = 0)
        {
            string writerId = (string)Session["WriterMail"];
            id = c.Writers.Where(x => x.WriterMail == writerId).Select(y => y.WriterID).FirstOrDefault();
            var values = wm.GetId(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult WriterProfil( Writer writer)
        {
            WriterValidator valid = new WriterValidator();
            ValidationResult result = valid.Validate(writer);

            if(result.IsValid )
            {

                string filename = Path.GetFileName(Request.Files[0].FileName);
                string fileextension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + filename + fileextension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                writer.WriterImage = "/Image/" + filename + fileextension;
                wm.WriterUpdate(writer);
                return RedirectToAction("AllHeading", "WriterPanel");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }






        int WriterIdInfo;
        public ActionResult MyHeading (string writerId)
        {
            writerId = (string)Session["WriterMail"];
            WriterIdInfo  = c.Writers.Where(x => x.WriterMail == writerId).Select(y => y.WriterID).FirstOrDefault();
            var values = hm.GetListByWriter(WriterIdInfo);
            return View(values);
        }


        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CatagoryName,
                                                      Value = x.CatagoryID.ToString()
                                                  }
                                                  ).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            string writermail = (string)Session["WriterMail"];
            var WriterInfo = c.Writers.Where(x => x.WriterMail == writermail).Select(y => y.WriterID).FirstOrDefault();

            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = WriterInfo;
            heading.HeadingStatus = true;
            hm.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
        }


        [HttpGet]
        public ActionResult EditWriterHeading(int id)
        {
            List<SelectListItem> valueheading = (from x in cm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CatagoryName,
                                                     Value = x.CatagoryID.ToString()
                                                 }
                                                 ).ToList();
            ViewBag.vlc = valueheading;
            var headingvalue = hm.GetHeading(id);
            return View(headingvalue);
        }

        [HttpPost]
        public ActionResult EditWriterHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteWriterHeading(int id)
        {
            var deletevalue = hm.GetHeading(id);
            deletevalue.HeadingStatus = false;
            hm.HeadingDelete(deletevalue);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading(int a = 1 /*  Kaçtan başlayacak */)
        {
            var headinglist = hm.GetList().ToPagedList(a, 4);
            return View(headinglist);
        }
    }
}