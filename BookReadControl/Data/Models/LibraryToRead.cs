using BookReadControl.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Guid { get; set; }

        private List<Book> _books { get; set; }

        public void AddBook(Book book)
        {
            Books.Add(book);

            //Сохраняем в базу
        }
    }
}
