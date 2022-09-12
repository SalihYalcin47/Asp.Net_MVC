using BusinesLayer.Concrete;
using BusinesLayer.ValidationRules;
using ClassLibrary1.EntityFreamwork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;   // verilerin sayfayı kaplayacak adedini belirlemek için kullanılır
using PagedList.Mvc;  // verilerin sayfayı kaplayacak adedini belirlemek için kullanılır

namespace ilkaspdeneme.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDall());

        public ActionResult Index(int a = 1)
        {
            var getvalue = cm.GetList().ToPagedList(a, 5);
            return View(getvalue);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator vd = new CategoryValidator();
            ValidationResult valid = vd.Validate(category);

            if (valid.IsValid)
            {
                category.CatagoryStatus = true;
                cm.CategoryAdd(category);
                return RedirectToAction("Index"); // yönlendir anlamında
            }
            else
            {
                foreach (var item in valid.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = cm.GetID(id);
            cm.CategoryDelete(categoryvalue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalue = cm.GetID(id);
            return View(categoryvalue);
        }
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
    }
} 