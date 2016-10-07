using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignalRChat.Models;

namespace SignalRChat.Controllers
{
    public class RobotController : Controller
    {
        // GET: Robot
        public ActionResult Index()
        {
            return View("_CreateSimpleBot",new SimpleBotModel(){Response = new List<string>(),Triggers = new List<TriggerWord>()});
        }


    }
}