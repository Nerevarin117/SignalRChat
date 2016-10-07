using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChat.Models
{
    public class SimpleBotModel 
    {

        /// <summary>
        /// List of trigger objects.
        /// </summary>
        public List<TriggerWord> Triggers { get; set; }

        /// <summary>
        /// If a list of triggerWord is not enough to achieve what the user has in mind, he can provid a regex instead.
        /// </summary>
        public string StrRegex { get; set; }

        /// <summary>
        /// Associate trigger list with response list, randomize between triggers and possible responses
        /// </summary>
        public enum Behavior
        {
            Associate,
            Randomize
        }
        /// <summary>
        /// Behavior of the response
        /// </summary>
        public Behavior ResponseBehavior { get; set; }

        /// <summary>
        /// Response list : can be a simple collection of sentence or Url convertible to image (jpg, png, gif).
        /// </summary>
        public List<string> Response { get; set; }
    }

    public class TriggerWord
    {
        public string LogicOP { get; set; }
        public string Word { get; set; }
    }

    public class BotBase
    {

        /// <summary>
        /// Public name of the bot
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Short description of the what is doing and why
        /// </summary>
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        /// <summary>
        /// Review elements
        /// </summary>
        public virtual List<RatingModel> Ratings { get; set; } 
    }

}