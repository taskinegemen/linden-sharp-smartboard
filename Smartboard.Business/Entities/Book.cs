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
        }

        public int Id
        { get; set; }

        public int UserId
        { get; set; }

        public bool IsDeleted
        { get; set; }

        public DateTime DateTime
        { get; set; }

        public string ImagePath
        { get; set; }

        public List<Page> Pages
        { get; set; }
    }
}
