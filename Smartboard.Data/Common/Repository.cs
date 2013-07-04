using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartboard.Data.Common
{
    public class Repository<T> where T: class
    {
        protected string path = "C:\\json\\";

        public Repository()
        {}

        public T Get()
        {
            throw new NotImplementedException();
        }

        public dynamic GetAll(string path)
        {
            dynamic array = null;
            using (StreamReader reader = new StreamReader(this.path + path))
            {
                string json = reader.ReadToEnd();
                array = JsonConvert.DeserializeObject(json);
                return array;
            }
        }
    }
}
