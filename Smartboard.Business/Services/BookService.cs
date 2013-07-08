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
            BookRepository repo = new BookRepository();
            return repo.GetUserBooks("userbooks.json");
        }

        public List<Page> GetThumbnails(int bookId)
        {
            List<Page> pages = new List<Page>();
            DirectoryInfo dir = new DirectoryInfo(RepositoryPath.Path + "thumbnails\\" + bookId.ToString());

            foreach (FileInfo file in dir.GetFiles())
            {
                Page page = new Page();
                page.ThumbnailPath = file.FullName;
                pages.Add(page);
            }

            return pages;
        }

        public Page GetPage(int bookId, int pageId)
        {
            Page page = new Page();

            using (StreamReader reader 
                = new StreamReader(RepositoryPath.Path + "pages\\" + bookId.ToString() + @"\" + pageId.ToString() + ".json"))
            {
                string json = reader.ReadToEnd();

                page = JsonConvert.DeserializeObject<Page>(json);
                page.ImagePath = RepositoryPath.Path + "pages\\" + bookId.ToString() + @"\" + pageId.ToString() + ".jpg";
            }
            if (page == null)
            {
                throw new BusinessException("Hata oluştu.");
            }

            return page;
        }

    }
}
