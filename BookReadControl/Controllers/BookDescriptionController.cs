using BookReadControl.Data.Interfaces;
using BookReadControl.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Controllers
{
    public class BookDescriptionController : Controller
    {
        private IBooks _books;
        private IBooksTypes _booksTypes;

        public BookDescriptionController(IBooks books, IBooksTypes types)
        {
            _books = books;
            _booksTypes = types;
        }

        public ViewResult BookDescription(int id)
        {
            Book book = _books.GetBook(id);
            BookType type = _booksTypes.GetBookType(book.BookTypeId);

            ViewBag.Title = type.Name;
            return View(book);
        }
    }
}
