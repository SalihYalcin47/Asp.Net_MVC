using BusinesLayer.Concrete;
using BusinesLayer.ValidationRules;
using ClassLibrary1.EntityFreamwork;
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
    public class WriterMessageController : Controller
    {
        // GET: WriterMessage
        MessageManager mm = new MessageManager(new EfMessageDall());
        MessageValidator mv = new MessageValidator();

        public ActionResult WriterMessageInbox()
        {

            string user = (string)Session["WriterMail"];
            var messagelist = mm.GetListInbox(user);
            return View(messagelist);
        }

        public PartialViewResult WriterSlideMenu(string user)
        {
            string mail = (string)Session["WriterMail"];

            ViewBag.inbox = mm.GetListInbox(mail).Count();
            ViewBag.sendbox = mm.GetListSendbox(mail).Count();
            return PartialView();
        }

        public ActionResult WriterSendbox()
        {
            string user = (string)Session["WriterMail"];
            var messagesendvalue = mm.GetListSendbox(user);
            return View(messagesendvalue);
        }

        public ActionResult WriterGetInboxMessageDetails(int id)
        {
            var value = mm.GetID(id);
            return View(value);
        }

        public ActionResult WriterGetSendMessageDetails(int id)
        {
            var value = mm.GetID(id);
            return View(value);
        }

        [HttpGet]
        public ActionResult WriterNewMessage()
        {
            return View();
        }


        [HttpPost]
        public ActionResult WriterNewMessage(Message message)
        {
            string sender = (string)Session["WriterMail"];

            ValidationResult result = mv.Validate(message);

            if (result.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                message.SenderMail = sender;
                mm.MessageAdd(message);
                return RedirectToAction("WriterMessageInbox");
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