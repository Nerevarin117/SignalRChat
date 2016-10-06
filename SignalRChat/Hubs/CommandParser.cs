using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRChat.Hubs
{
    public class CommandParser
    {

        public static void ParseMessage(IHubCallerConnectionContext clients,string name ,string message)
        {

            //Command /gif
            if (message.IndexOf("/gif", StringComparison.Ordinal) == 0)
            {
                var keywords = message.Replace("/gif", "").Split(' ');
                clients.All.addNewMessageToPage("NativeCommand",GipghyAPIHandler.FindGifOnKeyword(keywords));
                
            }

            //Command /w (whisper)
            if (message.IndexOf("/w", StringComparison.Ordinal) == 0)
            {
                var options = message.Replace("/w", "").Split(' ');
                if (options.Any())
                {
                    var target = options[0];
                    try
                    {
                        clients.User(target).send(name, message.Substring(target.Length));
                    }
                    catch (Exception e)
                    {
                        clients.User(name).send("Error", e.Message);
                    }
                }
                else
                {
                    clients.User(name).send("Error", "Incomplete Command.");
                }
                

            }
                
        }


    }
}