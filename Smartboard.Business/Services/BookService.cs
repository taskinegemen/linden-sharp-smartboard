using Smartboard.Business.Common;
using Smartboard.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartboard.Business.Repositories;
using System.IO;
using Newtonsoft.Json;

namespace Smartboard.Business.Services
{
    public class BookService
    {
        
        public BookService()
        {
        }

        public List<Book> GetBooks()
        {
            List<Book> books;
            BookRepository repo = new BookRepository();
            books =  repo.GetUserBooks();
            if (books == null)
            {
                throw new BusinessException("Kitap listesi okunamadı.");
            }
            return books;
        }

        public List<Page> GetPages(int bookId)
        {
            List<Page> pages = new List<Page>();
            BookRepository repo = new BookRepository();
            pages = repo.GetPages(bookId);
            return pages;
        }

        public Page GetPage(int bookId, int pageNo)
        {
            BookRepository repo = new BookRepository();
            return repo.GetPage(bookId, pageNo);
        }

    }
}
