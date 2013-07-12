using Smartboard.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartboard.Business.Repositories
{
    public class CategoryRepository
    {
        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            for (int i = 5; i < 13; i++)
            {
                Category category = new Category
                {
                    Title = i.ToString() + ".Sınıf"
                };
                categories.Add(category);
            }

            return categories;
        }

        public List<Course> GetCourses(string title)
        {
            List<Course> courses = new List<Course>();

            for (int i = 0; i < 10; i++)
            {
                Course course = new Course {
                    Title = title + " - Course-" + (i + 1).ToString()
                };
                courses.Add(course);
            }

            return courses;
        }

        public List<Note> GetNotes(string title)
        {
            List<Note> notes = new List<Note>();

            for (int i = 0; i < 10; i++)
            {
                Note note = new Note
                {
                    BookId = (i+1),
                    Title = title + " - Note-" + (i + 1).ToString()
                };

                notes.Add(note);
            }
            return notes;
        }

        public List<Multimedia> GetMultimedias(string title)
        {
            List<Multimedia> multimedias = new List<Multimedia>();

            for (int i = 0; i < 10; i++)
            {
                Multimedia multimedia = new Multimedia
                {
                    BookId = (i + 1),
                    Title = title + " - Multimedia-" + (i + 1).ToString()
                };
                multimedias.Add(multimedia);
            }
            return multimedias;
        }
    }
}
