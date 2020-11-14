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
        private IServiceProvider _provider;
        private IBooks _books;

        public UserLibraryController(IServiceProvider provider, IUser users, IBooks books, ILibrary library)
        {
            ISession session = provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            string libraryId = session.GetString("LibraryId") ?? Guid.NewGuid().ToString();
            session.SetString("LibraryId", libraryId);

            _provider = provider;
            _books = books;
            _user = users.GetUser(provider);
            _library = library.GetLibrary(libraryId);
        }

        public ViewResult BooksList()
        {
            ViewBag.Title = _user.Name;
            var books = _library.Books;
            return View(books);
        }

        public RedirectToActionResult addToLibrary(int id)
        {
            _library.AddBook(_books.GetBook(id));

            return RedirectToAction("BooksList");
        }
    }
}
