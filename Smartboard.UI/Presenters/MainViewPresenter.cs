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
    public class MainViewPresenter
    {
        public List<Book> GetBooks()
        {
            try
            {
                BookService service = new BookService();
                return service.GetBooks();
            }
            catch (BusinessException exc)
            {
                MessageBox.Show(exc.Message);
            }
            return null;
        }
    }
}
