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

        public List<Book> GetUserBooks(string path)
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
                    book.Id = (int)item.bookID;
                    book.UserId = (int)item.userID;

                    //book.IsDeleted = item.isDeleted;
                    book.DateTime = (DateTime)item.datetime;

                    book.ImagePath = RepositoryPath.Path + "covers\\" + book.Id.ToString() + ".jpg";

                    books.Add(book);
                }
            }

            return books;
        }

    }
}
