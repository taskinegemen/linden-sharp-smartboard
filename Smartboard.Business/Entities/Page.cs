using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartboard.Business.Entities
{
    public class Page
    {
        public Page()
        {
            this.Items = new List<PageItem>();
            this.Words = new List<PageWord>();
        }

        public int PageId
        {
            get;
            set;
        }

        public string ThumbnailPath
        { get; set; }

        public string ImagePath
        { get; set; }

        [JsonProperty(PropertyName = "page")]
        public int PageNo
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "width")]
        public int Width
        { get; set; }

        [JsonProperty(PropertyName = "height")]
        public int Height
        { get; set; }

        [JsonProperty(PropertyName = "items")]
        public List<PageItem> Items
        { get; set; }

        [JsonProperty(PropertyName = "words")]
        public List<PageWord> Words
        { get; set; }

        public Image Image
        {
            get;
            set;
        }

    }
}
