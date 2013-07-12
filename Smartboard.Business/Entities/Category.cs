using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartboard.Business.Entities
{
    public class Category
    {
        public Category()
        {
            this.Courses = new List<Course>();
            this.Id = Guid.NewGuid();
        }

        public Guid Id
        { get; set; }

        public string Title
        { get; set; }

        public List<Course> Courses
        { get; set; }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
