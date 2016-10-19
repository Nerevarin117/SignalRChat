using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using System.Text.RegularExpressions;

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
                    clients.All.addNewMessageToPage(name, "<img class='responsive' title='Powered By Giphy' src='" + parameter+ "' alt='Powered By Giphy'/>");
                }
                else
                {
                    var keywords = message.Replace("/gif", "").Replace(" ","+");
                    clients.All.addNewMessageToPage(name, GiphyAPIHandler.FindGifOnKeyword(keywords));
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
            if (message.IndexOf("/meme", StringComparison.Ordinal) == 0)
            {
                var regex = new Regex("\\\".*?\\\"");
                var match = regex.Matches(message);
                if( match.Count != 3)
                {
                    clients.User(name).send("Error", "Invalid Parameters for the command /meme.");
                }
                else
                {
                    var url = match[0].Value.Replace("\"","");
                    var topCaption = match[1].Value.Replace("\"", "");
                    var botCaption = match[2].Value.Replace("\"", "");
                    Uri uriResult;
                    bool isUrl = Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                    if (isUrl)
                    {
                        clients.All.addNewMessageToPage(name, "<div class='meme' style=background:no-repeat url('" + url + "')><p class='top'>" + topCaption + "</p>  <p class='bottom'>" + botCaption + "</p></div>");
                    }
                    else
                    {
                        clients.User(name).send("Error", "Invalid Url.");

                    }
                }
                

            }
       }
    }
}