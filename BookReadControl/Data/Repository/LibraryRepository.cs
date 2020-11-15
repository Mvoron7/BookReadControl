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

        public LibraryToRead GetLibrary(string id)
        {
            return appDBContent.Libraries.FirstOrDefault(l => l.Guid.Equals(id));
        }
    }
}
