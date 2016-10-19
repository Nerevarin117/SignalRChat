using System.Globalization;
using SignalRChat.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignalRChat.Models;

namespace SignalRChat.Controllers
{
    public class GifController : Controller
    {
        public PartialViewResult Select(string keywords,int offset=0,int limit=5)
        {
            ModelState.Clear();
            var selection = new SelectGifViewModel
            {
                Keywords = keywords,
                Offset = (offset + limit).ToString(CultureInfo.InvariantCulture),
                Limit = limit.ToString(CultureInfo.InvariantCulture),
                Selection = GiphyAPIHandler.GifListFilter(keywords, limit, offset).data
            };
            return PartialView("_GifSelector", selection);
        }

        public PartialViewResult Display(string url,string username,string keywords)
        {

            return PartialView("_GifDisplayer");
        }

        public PartialViewResult MemeBuilder()
        {
            return PartialView("_MemeBuilder");
        }
    }
}