using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartboard.Business.Entities
{
    public class Book
    {
        public Book()
        {
            this.Pages = new List<Page>();
        }

        [JsonProperty(PropertyName="bookID")]
        public int BookId
        { get; set; }

        [JsonProperty(PropertyName="userID")]
        public int UserId
        { get; set; }

        [JsonProperty(PropertyName="isDeleted")]
        public bool IsDeleted
        { get; set; }

        [JsonProperty(PropertyName="datetime")]
        public DateTime DateTime
        { get; set; }

        public string ImagePath
        { get; set; }

        public List<Page> Pages
        { get; set; }
    }
}
