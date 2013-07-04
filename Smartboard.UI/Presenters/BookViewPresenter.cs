using Smartboard.Business.Common;
using Smartboard.Business.Services;
using Smartboard.Data.Entities;
using Smartboard.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartboard.UI.Presenters
{
    public class BookViewPresenter
    {
        private BookView view;

        public BookViewPresenter(BookView view)
        {
            this.view = view;
        }

        public List<Page> GetPages(int bookdId)
        {
            try
            {
                BookService service = new BookService();
                return service.GetThumbnails(bookdId);
            }
            catch (BusinessException exc)
            {
                MessageBox.Show(exc.Message);
                return null;
            }
        }

        public Page GetPage(int bookId, int pageId)
        {
            try
            {
                //foreach(Page page in this.view.Pages)
                //{
                //    if (page.Width != 0)
                //    {
                //        return page;
                //    }
                //}


                BookService service = new BookService();
                return service.GetPage(bookId, pageId);
            }
            catch (BusinessException exc)
            {
                MessageBox.Show(exc.Message);
                return null;
            }
        }
    }
}
