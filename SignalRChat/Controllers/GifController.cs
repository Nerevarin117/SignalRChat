using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRChat.Controllers
{
    public class GifController : Controller
    {
        public PartialViewResult SelectGif(int offset = 0,int limit=5)
        {

            return PartialView("_GifSelector");
        }

        public PartialViewResult DisplayGif(string username,string keywords)
        {

            return PartialView("_GifDisplayer");
        }
    }
}