using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChat.Models
{
    public class GiphyData
    {
        public List<GifModel> data { get; set; } 
    }

    public class GifModel
    {
        public string source_tld { get; set; }
        public ImageModel images { get; set; }
    }

    public class ImageModel
    {

        public ImageSubType fixed_height_small { get; set; }
    }

    public class ImageSubType
    {
        public string url { get; set; }
    }


    /// <summary>
    /// Used to get the stickers
    /// </summary>
    public class StickerData
    {
        public StickerModel data { get; set; }

    }
    /// <summary>
    /// Used to get the stickers
    /// </summary>
    public class StickerModel
    {
        public string fixed_height_small_url { get; set; }

    }
}