using BusinesLayer.Concrete;
using ClassLibrary1.EntityFreamwork;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;
using PagedList;
using System.Web.Mvc;

namespace ilkaspdeneme.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading

        HeadingManager hm = new HeadingManager(new EfHeadingDall());
        CategoryManager cm = new CategoryManager(new EfCategoryDall());
        WriterManager wm = new WriterManager(new EfWriterDall());
        public ActionResult Index(int a = 1)
        {
            var headingvalues = hm.GetList().ToPagedList(a, 5);
            return View(headingvalues);
        }


        public ActionResult HeadingReport()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
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
            List<SelectListItem> valuewriter = (from y in wm.Getlist()
                                                  select new SelectListItem
                                                  {
                                                      Text = y.WriterName,
                                                      Value = y.WriterID.ToString()
                                                  }
                                                  ).ToList();
            ViewBag.vlc= valuecategory;
            ViewBag.vlc2 = valuewriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(heading);
            return RedirectToAction("Index");
        }

        [HttpGet] 
        public ActionResult EditHeading(int id)
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
        public ActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var deletevalue = hm.GetHeading(id);
            deletevalue.HeadingStatus = false;
            hm.HeadingDelete(deletevalue);
            return RedirectToAction("Index");
        }


        public ActionResult HeadingCategory(int id)
        {
            
            var values = hm.GetLisCategoryt(id);
            return View(values);
        }
    }
}