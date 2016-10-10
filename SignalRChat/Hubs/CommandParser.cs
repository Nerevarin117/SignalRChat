using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRChat.Hubs
{
    /// <summary>
    /// Command parser to handle possible commands sent by users, some of the commands at handle on the client side , cf Commands.js file.
    /// </summary>
    public class CommandParser
    {

        public static void ParseMessage(IHubCallerConnectionContext clients,string name ,string message)
        {

            //Command /gif
            if (message.IndexOf("/gif", StringComparison.Ordinal) == 0)
            {
                Uri uriResult;
                var parameter = message.Replace("/gif", "");
                bool isUrl = Uri.TryCreate(parameter, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                if (isUrl)
                {
                    clients.All.addNewMessageToPage("Commander", "<img class='responsive' height='32' title='Powered By Giphy' src='" + parameter+ "' alt='Powered By Giphy'/>");
                }
                else
                {
                    var keywords = message.Replace("/gif", "").Replace(" ","+");
                    clients.All.addNewMessageToPage("NativeCommand", GipghyAPIHandler.FindGifOnKeyword(keywords));
                }
                
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