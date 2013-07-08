using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartboard.Business.Entities
{
    public class User
    {
        public User()
        { }

        [JsonProperty(PropertyName = "status")]
        public bool Status
        { get; set; }

        [JsonProperty(PropertyName = "token")]
        public string Token
        { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email
        { get; set; }

        [JsonProperty(PropertyName = "firstname")]
        public string FirstName
        { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public string LastName
        { get; set; }


    }
}
