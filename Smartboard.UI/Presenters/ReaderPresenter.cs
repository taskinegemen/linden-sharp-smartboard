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
    public class ReaderPresenter
    {
        public void SetPageThumbnails(Book book)
        {
            try
            {
                BookService service = new BookService();
                book.PageThumbnails = service.GetPageThumbnails(book.BookId);
            }
            catch (BusinessException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public Page GetPage(Book book, int pageId)
        {
            try
            {
                Page page = book.Pages.Find(p => p.PageNo == pageId);
                if (page == null)
                {
                    BookService service = new BookService();
                    return service.GetPage(book.BookId, pageId);
                }
                else
                {
                    return page;
                }
            }
            catch (BusinessException exc)
            {
                MessageBox.Show(exc.Message);
            }
            return null;
        }
    }


}
