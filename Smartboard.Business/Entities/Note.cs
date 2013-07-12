using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartboard.Business.Entities
{
    public class Note
    {
        public Note()
        {
        }

        public int BookId { get; set; }

        public string Title
        {
            get;
            set;
        }

        public override string ToString()
        {
            return this.Title;
        }

    }
}
