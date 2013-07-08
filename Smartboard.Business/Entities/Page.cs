using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartboard.Business.Entities
{
    public class Page
    {
        public Page()
        {
        }

        public string ThumbnailPath
        { get; set; }

        public string ImagePath
        { get; set; }

        [JsonProperty(PropertyName="status")]
        public bool Status
        {
            get;
            set;
        }

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

    }
}
