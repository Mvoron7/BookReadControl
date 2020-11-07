using BookReadControl.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Data.Interfaces
{
    public interface IBooks
    {
        IEnumerable<Book> Books { get; }

        Book GetBook(int id);
    }
}
