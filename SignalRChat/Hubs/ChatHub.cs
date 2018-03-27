using System;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalRChat.Hubs;

namespace SignalRChat
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            if(message.IndexOf("/", System.StringComparison.Ordinal) == 0)
            {
                CommandParser.ParseMessage(Clients, name, message);
            }
            else
            {
                message = StickerParser.ParseStickers(message);

                //Clients.All.addNewMessageToPage(name, message);
                //Clients.All.addHtmlToPage("<i>test<i>");
                Clients.All.useReactToRenderMessage(new { message = message });
                //go renvoyer du json et utiliser React

            }


        }
    }
}