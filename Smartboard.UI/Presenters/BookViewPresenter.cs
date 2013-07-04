using Smartboard.Business.Common;
using Smartboard.Business.Services;
using Smartboard.Data.Entities;
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
        public BookViewPresenter()
        { }

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
    }
}
