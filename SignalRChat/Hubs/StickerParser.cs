using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SignalRChat.Hubs
{
    public class StickerParser
    {
        private const string Pattern = @"\!(.*?)\!";

        public static string ParseStickers(string input)
        {

            return Regex.Replace(input, Pattern, GipghyAPIHandler.FindStickerOnKeyword);

        }
    }
}