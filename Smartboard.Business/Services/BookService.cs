using Smartboard.Business.Common;
using Smartboard.Data.Entities;
using Smartboard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartboard.Data.Repositories;

namespace Smartboard.Business.Services
{
    public class BookService
    {
        
        public BookService()
        {
        }

        public List<Book> GetBooks()
        {
            BookRepository repo = new BookRepository();
            return repo.GetUserBooks("userbooks.json");
        }

    }
}
