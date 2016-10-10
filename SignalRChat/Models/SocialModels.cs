using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace SignalRChat.Models
{

    public class RatingModel
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}