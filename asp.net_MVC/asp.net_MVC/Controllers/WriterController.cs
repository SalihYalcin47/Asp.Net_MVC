using BusinesLayer.Concrete;
using BusinesLayer.ValidationRules;
using ClassLibrary1.EntityFreamwork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp.net_MVC.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDall());
        WriterValidator writervalidator = new WriterValidator();
        HeadingManager hm = new HeadingManager(new EfHeadingDall());
        public ActionResult Index(int a = 1)
        {
            var writervalues = writerManager.Getlist().ToPagedList(a, 10);
            return View(writervalues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {

            ValidationResult result = writervalidator.Validate(p);
            if (result.IsValid)
            {
                writerManager.WriterAdd(p);
                return RedirectToAction("Index");
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

        [HttpGet]
        public ActionResult EditWriters(int id)
        {
            var writervalue = writerManager.GetId(id);
            return View(writervalue);
        }

        [HttpPost]
        public ActionResult EditWriters(Writer writer)
        {
            ValidationResult result = writervalidator.Validate(writer);
            if (result.IsValid)
            {
                writerManager.WriterUpdate(writer);
                return RedirectToAction("Index");
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

        public ActionResult GetWriterHeading(int id)
        {

            var values = hm.GetListByWriter(id);
            return View(values);
        }
    }
}