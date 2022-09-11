using BusinesLayer.Concrete;
using BusinesLayer.ValidationRules;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;
using ClassLibrary1.EntityFreamwork;

namespace ilkaspdeneme.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EfCategoryDall());
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult GetCategorylist()
        {
            var GetValue = cm.GetList();
            return View(GetValue);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
           CategoryValidator cv = new CategoryValidator();
            ValidationResult reesults = cv.Validate(p);

            if (reesults.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCategorylist");
            }
            else
            {
                foreach (var item in reesults.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

    }
}