using Smartboard.Business.Common;
using Smartboard.Business.Entities;
using Smartboard.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartboard.Business.Services
{
    public class CategoryService
    {
        public List<Category> GetCategories()
        {
            List<Category> categories;
            CategoryRepository repo = new CategoryRepository();
            categories = repo.GetCategories();
            if (categories == null)
            {
                throw new BusinessException("Kategoriler oluşturulamadı.");
            }
            return categories;
        }

        public List<Course> GetCourses(string title)
        {
            List<Course> courses;
            CategoryRepository repo = new CategoryRepository();
            courses = repo.GetCourses(title);
            if (courses == null)
            {
                throw new BusinessException("Dersler oluşturulamadı.");
            }
            return courses;
        }

        public List<Note> GetNotes(string title)
        {
            List<Note> notes;
            CategoryRepository repo = new CategoryRepository();
            notes = repo.GetNotes(title);
            if (notes == null)
            {
                throw new BusinessException("Notlar oluşturulamadı.");
            }
            return notes;
        }

        public List<Multimedia> GetMultimedias(string title)
        {
            List<Multimedia> multimedias;
            CategoryRepository repo = new CategoryRepository();
            multimedias = repo.GetMultimedias(title);
            if (multimedias == null)
            {
                throw new BusinessException("Multimedyalar oluşturulamadı.");
            }
            return multimedias;
        }
    }
}
