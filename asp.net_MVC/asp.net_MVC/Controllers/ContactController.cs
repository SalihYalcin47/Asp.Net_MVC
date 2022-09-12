using BusinesLayer.Concrete;
using BusinesLayer.ValidationRules;
using ClassLibrary1.EntityFreamwork;
using DataAcessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp.net_MVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDall());
        MessageManager mm = new MessageManager(new EfMessageDall());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactvalue = cm.GetList();
            return View(contactvalue);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalue = cm.GetID(id);
            return View(contactvalue);
        }
        public PartialViewResult SideMenu(string user)
        {

            var contactList = cm.GetList();

            ViewBag.contactCount = contactList.Count();

             user = (string)Session["AdminUserName"];

            ViewBag.inbox = mm.GetListInbox(user).Count();
            ViewBag.sendbox = mm.GetListSendbox(user).Count();
            return PartialView();
        }
    }
}