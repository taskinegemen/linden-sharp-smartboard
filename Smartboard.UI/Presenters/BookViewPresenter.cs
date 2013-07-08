using Smartboard.Business.Common;
using Smartboard.Business.Services;
using Smartboard.Business.Entities;
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

        public List<Page> GetPages(int bookId)
        {
            try
            {
                BookService service = new BookService();
                return service.GetPages(bookId);
            }
            catch (BusinessException exc)
            {
                MessageBox.Show(exc.Message);
                return null;
            }
        }

        public Page GetPage(int bookId, int pageNo)
        {
            try
            {
                BookService service = new BookService();
                return service.GetPage(bookId, pageNo);
            }
            catch (BusinessException exc)
            {
                MessageBox.Show(exc.Message);
                return null;
            }
        }
    }
}
