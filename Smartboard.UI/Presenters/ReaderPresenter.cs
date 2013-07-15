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
    }


}
