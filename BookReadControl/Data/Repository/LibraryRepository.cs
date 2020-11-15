using BookReadControl.Data.Interfaces;
using BookReadControl.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Data.Repository
{
    public class LibraryRepository : ILibrary
    {
        private readonly AppDBContent appDBContent;

        public LibraryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public void AddBook(string id, Book book)
        {
            LibraryToRead library = appDBContent.Libraries.FirstOrDefault(l => l.Guid.Equals(id));

            if (library == null)
            {
                library = new LibraryToRead() { Guid = id };
                appDBContent.Libraries.Add(library);
            }
            library.AddBook(book);
            appDBContent.SaveChanges();
        }

        public LibraryToRead GetLibrary(string id)
        {
            LibraryToRead library = appDBContent.Libraries.FirstOrDefault(l => l.Guid.Equals(id));

            if (library == null)
            {
                library = new LibraryToRead() { Guid = id };
                appDBContent.Libraries.Add(library);
                appDBContent.SaveChanges();
            }
            return library;
        }
    }
}
