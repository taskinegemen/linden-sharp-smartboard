using Smartboard.Data.Entities;
using Smartboard.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Smartboard.Data.Repositories
{
    public class BookRepository: Repository<Book>
    {

        public BookRepository()
        {
        }

        public Book Get()
        {
            return this.Get();
        }

        public List<Book> GetUserBooks(string path)
        {
            List<Book> books = new List<Book>();
            
            dynamic array = base.GetAll(path);

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

                    book.ImagePath = base.path + "covers\\" + book.Id.ToString() + ".jpg";

                    books.Add(book);
                }
            }

            return books;
        }

    }
}
