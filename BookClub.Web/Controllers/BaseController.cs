using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookClub.Web.Models;
using BookClub.Core.Enums;
using BookClub.Web.Extensions;

namespace BookClub.Web.Controllers
{
    public class BaseController : Controller
    {
        public ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RedirectToHome()
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public bool Error(string message)       
        {
            var pageMessage = new PageMessage(message, PageMessageType.Error, true);
            return TryAddPageMessage(pageMessage);
        }

        public bool Success(string message)
        {
            var pageMessage = new PageMessage(message, PageMessageType.Success, true);
            return TryAddPageMessage(pageMessage);
        }

        public bool Info(string message)
        {
            var pageMessage = new PageMessage(message, PageMessageType.Info, true);
            return TryAddPageMessage(pageMessage);
        }

        public string GetTextForMessage(Message message)
        {
            switch (message)
            {
                case Message.Error:
                    return "Something went wrong, please try again.";
                case Message.Success:
                    return "Success!";
                case Message.NotFound:
                    return "We couldn't find what you were looking for. Please try again.";
                default:
                    return string.Empty;
            }
        }
        public bool Error(Message message)
        {
            return Error(GetTextForMessage(message));
        }

        public bool Info(Message message)
        {
            return Info(GetTextForMessage(message));
        }

        public bool Success(Message message)
        {
            return Success(GetTextForMessage(message));
        }


        public void AddPageMessage(PageMessage pageMessage)
        {
            var pageMessages = TempData.Get<List<PageMessage>>("Messages")
                ?? new List<PageMessage>();

            pageMessages.Add(pageMessage);
            TempData.Put("Messages", pageMessages);
        }

        private bool TryAddPageMessage(PageMessage pageMessage)
        {
            if (!HasPageMessage(pageMessage))
            {
                AddPageMessage(pageMessage);
                return true;
            }
            return false;
        }

        private bool HasPageMessage(PageMessage pageMessage)
        {
            var pageMessages = TempData.Get<List<PageMessage>>("Messages");
            if (pageMessages != null)
            {
                return pageMessages.Contains(pageMessage);
            }

            return false;
        }
    }
}
