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
    public class UserLibraryController : Controller
    {
        private User _user;
        private LibraryToRead _library;

        public UserLibraryController(IServiceProvider provider, IUser users, IBooks books)
        {
            _user = users.GetUser(provider);
            _library = LibraryToRead.GetLibrary(provider);
        }

        public ViewResult BooksList()
        {
            ViewBag.Title = _user.Name;
            var books = _library.Books;
            return View(books);
        }

        public RedirectToActionResult addToLibrary(int id, IServiceProvider provider, IBooks books)
        {
            LibraryToRead library = LibraryToRead.GetLibrary(provider);
            library.AddBook(books.GetBook(id));

            return RedirectToAction("BooksList");
        }
    }
}
