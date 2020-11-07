using BookReadControl.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Data.Interfaces
{
    public interface IBooksTypes
    {
        IEnumerable<BookType> BookTypes { get; }
    }
}
