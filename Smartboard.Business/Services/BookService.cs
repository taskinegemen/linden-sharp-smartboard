using Smartboard.Business.Common;
using Smartboard.Data.Entities;
using Smartboard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartboard.Data.Repositories;
using System.IO;

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

        public List<Page> GetThumbnails(int bookId)
        {
            List<Page> pages = new List<Page>();
            DirectoryInfo dir = new DirectoryInfo(@"C:\json\thumbnails\" + bookId.ToString());

            foreach (FileInfo file in dir.GetFiles())
            {
                Page page = new Page();
                page.ThumbnailPath = file.FullName;
                pages.Add(page);
            }

            return pages;
        }

    }
}
