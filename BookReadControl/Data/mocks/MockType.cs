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
        public IEnumerable<BookType> BookTypes
        {
            get => new List<BookType>()
            {
                new BookType()
                {
                    Id = 1,
                    Name = "Справочник",
                    Description = "Справочник",
                },
                new BookType()
                {
                    Id = 2,
                    Name = "Справочник по языку",
                    Description = "Справочник по языку",
                },
                new BookType()
                {
                    Id = 3,
                    Name = "Рекомендации ко стилю кодирования",
                    Description = "Рекомендации ко стилю кодирования",
                }
            };
        }
    }
}
