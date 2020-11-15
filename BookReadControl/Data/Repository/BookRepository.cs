using BookReadControl.Data.Interfaces;
using BookReadControl.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Data.Repository
{
    public class BookRepository : IBooks
    {
        private readonly AppDBContent appDBContent;

        public BookRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Book> Books { get => appDBContent.Books; }       

        public Book GetBook(int id)
        {
            return Books.FirstOrDefault(b => b.Id == id);
        }
    }
}
