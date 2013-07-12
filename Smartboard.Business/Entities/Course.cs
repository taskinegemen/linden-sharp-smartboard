using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartboard.Business.Entities
{
    public class Course
    {
        public Course()
        {
            this.Notes = new List<Note>();
            this.Multimedias = new List<Multimedia>();
        }

        public string Title
        {
            get;
            set;
        }

        public List<Note> Notes
        {
            get;
            set;
        }

        public List<Multimedia> Multimedias
        { get; set; }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
