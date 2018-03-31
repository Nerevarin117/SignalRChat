using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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

        // GET: Robot
        public ActionResult Display()
        {
            return View("_DisplayBot");
        }

        [HttpPost]
        public JsonResult UploadIcon(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Content/Bots/Icons"),"default.jpg");
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR : " + ex.Message;
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

    }
}