using BookReadControl.Data.Interfaces;
using BookReadControl.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Data.mocks
{
    public class MockType : IBooksTypes
    {
        public IEnumerable<BookType> BookTypes => Constants.Types;

        public BookType GetBookType(int id)
        {
            return BookTypes.Where(bt => bt.Id == id).FirstOrDefault();
        }
    }
}
