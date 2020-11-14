using BookReadControl.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Data.Models
{
    public class LibraryToRead
    {
        public List<Book> Books
        {
            get
            {
                if (_books == null)
                {
                    // Тут получение списка из БД по LibraryId.
                    _books = new List<Book>();
                }

                return _books;
            }
        }

        public string Id;

        private List<Book> _books;

        public static LibraryToRead GetLibrary(IServiceProvider provider)
        {
            ISession session = provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            string libraryId = session.GetString("LibraryId") ?? Guid.NewGuid().ToString();

            session.SetString("LibraryId", libraryId);

            return new LibraryToRead()
            {
                Id = libraryId,
            };
        }

        public void AddBook(Book book)
        {
            Books.Add(book);

            //Сохраняем в базу
        }
    }
}
