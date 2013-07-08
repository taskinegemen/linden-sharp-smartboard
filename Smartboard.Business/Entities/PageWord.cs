using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartboard.Business.Entities
{
    public class PageWord
    {
        public PageWord()
        { }

        [JsonProperty(PropertyName="bookID")]
        public int BookId
        { get; set; }

        [JsonProperty(PropertyName = "page")]
        public int Page
        { get; set; }

        [JsonProperty(PropertyName = "paragraph")]
        public int Paragraph
        { get; set; }

        [JsonProperty(PropertyName = "luX")]
        public double LeftUpperX
        { get; set; }

        [JsonProperty(PropertyName = "luY")]
        public double LeftUpperY
        { get; set; }

        [JsonProperty(PropertyName = "rlX")]
        public double RightLowerX
        { get; set; }

        [JsonProperty(PropertyName = "rlY")]
        public double RightLowerY
        { get; set; }

        [JsonProperty(PropertyName = "height")]
        public double Height
        { get; set; }

        [JsonProperty(PropertyName = "width")]
        public double Width
        { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text
        { get; set; }
    }
}
