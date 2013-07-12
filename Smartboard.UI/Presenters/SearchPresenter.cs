using Smartboard.Business.Common;
using Smartboard.Business.Entities;
using Smartboard.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartboard.UI.Presenters
{
    public class SearchPresenter
    {
        public SearchPresenter()
        {
        }

        public List<Category> GetCategories()
        {
            try
            {
                CategoryService service = new CategoryService();
                return service.GetCategories();
            }
            catch (BusinessException exc)
            {
                MessageBox.Show(exc.Message);
            }

            return new List<Category>();
        }

        public void GetCourses(Category category)
        {
            try
            {
                if (category.Courses.Count == 0)
                {
                    CategoryService service = new CategoryService();
                    category.Courses = service.GetCourses(category.Title);
                }
            }
            catch(BusinessException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void GetNotes(Course course)
        {
            try
            {
                if (course.Notes.Count == 0)
                {
                    CategoryService service = new CategoryService();
                    course.Notes = service.GetNotes(course.Title);
                }
            }
            catch (BusinessException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void GetMultimedias(Course course)
        {
            try
            {
                if (course.Multimedias.Count == 0)
                {
                    CategoryService service = new CategoryService();
                    course.Multimedias = service.GetMultimedias(course.Title);
                }
            }
            catch (BusinessException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
