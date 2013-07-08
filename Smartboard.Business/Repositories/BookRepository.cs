using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Smartboard.Business.Entities;
using Newtonsoft.Json;
using Smartboard.Business.Common;

namespace Smartboard.Business.Repositories
{
    public class BookRepository
    {

        public BookRepository()
        {
        }

        public Book Get(int bookId)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetUserBooks()
        {
            List<Book> books = new List<Book>();

            dynamic array = null;
            using (StreamReader reader = new StreamReader(RepositoryPath.Path + "userbooks.json"))
            {
                string json = reader.ReadToEnd();
                array = JsonConvert.DeserializeObject(json);
            }

            if (array == null)
            {
                return array;
            }

            foreach (var item in array.books)
            { 
                if ((int)item.isDeleted == 0)
                {
                    Book book = new Book();
                    book.BookId = (int)item.bookID;
                    book.UserId = (int)item.userID;

                    //book.IsDeleted = item.isDeleted;
                    book.DateTime = (DateTime)item.datetime;

                    book.ImagePath = RepositoryPath.Path + "covers\\" + book.BookId.ToString() + ".jpg";

                    books.Add(book);
                }
            }

            return books;
        }

        public List<Page> GetPages(int bookId)
        {
            DirectoryInfo dir = new DirectoryInfo(RepositoryPath.Path + "thumbnails\\" + bookId.ToString());
            List<Page> pages = new List<Page>();

            foreach (FileInfo file in dir.GetFiles())
            {
                Page page = new Page();

                page.ThumbnailPath = file.FullName;

                string[] arr1 = file.Name.Split('-');
                string[] arr2 = arr1[1].Split('.');

                page.PageNo = int.Parse(arr2[0]);

                pages.Add(page);
            }
            return pages;
        }

        public Page GetPage(int bookId, int pageNo)
        {
            Page page = new Page();

            using (StreamReader reader
                = new StreamReader(RepositoryPath.Path + "pages\\" + bookId.ToString() + @"\" + pageNo.ToString() + ".json"))
            {
                string json = reader.ReadToEnd();

                page = JsonConvert.DeserializeObject<Page>(json);
                page.ImagePath = RepositoryPath.Path + "pages\\" + bookId.ToString() + @"\" + pageNo.ToString() + ".jpg";
                page.ThumbnailPath = RepositoryPath.Path + "thumbnails\\" + bookId.ToString() + @"\" + pageNo.ToString() + ".jpg";

                page.ReadBefore = true;
            }

            return page;
        }

    }
}
