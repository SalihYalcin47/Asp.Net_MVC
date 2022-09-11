using BusinesLayer.Concrete;
using BusinesLayer.ValidationRules;
using DataAcessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp.net_MVC.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message

        MessageManager mm = new MessageManager(new EfMessageDall());
        MessageValidator mv = new MessageValidator();

        [Authorize]
        public ActionResult Inbox()
        {
            string user = (string)Session["AdminUserName"];
            var messagelist = mm.GetListInbox(user);
            return View(messagelist);
        }
        [Authorize]
        public ActionResult Sendbox()
        {
            string user = (string)Session["AdminUserName"];
            var messagesendvalue = mm.GetListSendbox(user);
            return View(messagesendvalue);
        }

        [Authorize]
        public ActionResult GetInboxMessageDetails(int id)
        {
            var value = mm.GetID(id);
            return View(value);
        }

        [Authorize]
        public ActionResult GetSendMessageDetails(int id)
        {
            var value = mm.GetID(id);
            return View(value);
        }

        [Authorize]
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult result = mv.Validate(message);

            if (result.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(message); 
                return RedirectToAction("SendBox");
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
    }
}