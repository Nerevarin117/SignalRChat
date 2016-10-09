using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using Newtonsoft.Json;
using SignalRChat.Models;

namespace SignalRChat.Hubs
{


    /// <summary>
    /// Class to handle calls to giphy API to retreive random gifs
    /// Reference : https://github.com/Giphy/GiphyAPI
    /// </summary>
    public static class GipghyAPIHandler
    {
        private const string PublicKey = "dc6zaTOxFJmzC";
        private const string BaseUrl = "http://api.giphy.com/v1/";

        public static string FindGifOnKeyword(string[] keywords)
        {
            Stream dataStream = null;
            string jsonResponse = "KO";

            try
            {
                WebRequest webRequest = WebRequest.Create(BaseUrl + "gifs/random?tag=" + String.Join("+", keywords) + "&api_key=" + PublicKey);
                webRequest.Method = "GET";
                webRequest.Timeout = 1000;
                webRequest.ContentType = "application/json";
                var response = (HttpWebResponse)webRequest.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                    dataStream = response.GetResponseStream();
                if (dataStream != null)
                {
                    var reader = new StreamReader(dataStream);
                    jsonResponse = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                }

                response.Close();

                var obj = (StickerData)JsonConvert.DeserializeObject(jsonResponse, typeof(StickerData));

                return "<img title='Powered By Giphy' src='" + obj.data.fixed_height_small_url + "' alt='Powered By Giphy'/>";
            }
            catch (Exception e)
            {
                return "<p>Error Executing Gif Feature<p>";
            }
        }

        public static string FindStickerOnKeyword(Match keyword)
        {
            return FindStickerOnKeyword(keyword.Value.Replace("!", ""));
        }

        public static string FindStickerOnKeyword(string keyword)
        {
            Stream dataStream = null;
            string jsonResponse = "KO";

            try
            {
                WebRequest webRequest = WebRequest.Create(BaseUrl + "stickers/random?tag=" + keyword + "&api_key=" + PublicKey);
                webRequest.Method = "GET";
                webRequest.Timeout = 1000;
                webRequest.ContentType = "application/json";
                var response = (HttpWebResponse)webRequest.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                    dataStream = response.GetResponseStream();
                if (dataStream != null)
                {
                    var reader = new StreamReader(dataStream);
                    jsonResponse = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                }

                response.Close();

                var obj = (StickerData)JsonConvert.DeserializeObject(jsonResponse, typeof(StickerData));

                return "<img class='responsive' height='32' title='Powered By Giphy' src='" + obj.data.fixed_height_small_url + "' alt='Powered By Giphy'/>";
            }
            catch (Exception e)
            {
                return "<p>Error Executing Sticker Feature <p>";
            }
        }

        public static string FindGifListOnKeyword(string keyword)
        {
            Stream dataStream = null;
            string jsonResponse = "KO";

            try
            {
                WebRequest webRequest = WebRequest.Create(BaseUrl + "gifs/search?q=" + keyword + "&api_key=" + PublicKey);
                webRequest.Method = "GET";
                webRequest.Timeout = 1000;
                webRequest.ContentType = "application/json";
                var response = (HttpWebResponse)webRequest.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                    dataStream = response.GetResponseStream();
                if (dataStream != null)
                {
                    var reader = new StreamReader(dataStream);
                    jsonResponse = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                }

                response.Close();

                var obj = (GiphyData)JsonConvert.DeserializeObject(jsonResponse, typeof(GiphyData));
                //TODO return list of selectable gifs to be sent or do it client side?
                return "";
            }
            catch (Exception e)
            {
                return "<p>Error Executing Sticker Feature <p>";
            }
        }

    }
}