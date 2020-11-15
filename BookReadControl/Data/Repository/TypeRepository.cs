using BookReadControl.Data.Interfaces;
using BookReadControl.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Data.Repository
{
    public class TypeRepository : IBooksTypes
    {
        private readonly AppDBContent appDBContent;

        public TypeRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<BookType> BookTypes { get => appDBContent.Types; }

        public BookType GetBookType(int id)
        {
            return BookTypes.FirstOrDefault(t => t.Id == id);
        }
    }
}
