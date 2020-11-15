using BookReadControl.Data.Interfaces;
using BookReadControl.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Data.mocks
{
    public class MockBooks : IBooks
    {
        public IEnumerable<Book> Books => Constants.Books;

        public Book GetBook(int id)
        {
            return Books.Where(b => b.Id == id).FirstOrDefault();
        }
    }
}
