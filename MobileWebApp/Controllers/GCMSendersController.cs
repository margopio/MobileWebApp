using MobileWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileWebApp.Controllers
{
    public class GCMSendersController : Controller
    {
        // GET: GCMSenders
        public ActionResult Index()
        {
            ListGCMSendersViewModel gcmSenders = new ListGCMSendersViewModel();
            gcmSenders.GCMSenders = GCMSenderIDRepository.Responses;

            return View(gcmSenders);
        }
    }
}