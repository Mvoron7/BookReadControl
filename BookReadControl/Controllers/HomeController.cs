using BookReadControl.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISession _session;

        public HomeController(IServiceProvider provider)
        {
            _session = provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        }

        public ViewResult Index()
        {
            return View();
        }

        public RedirectToActionResult LogIn(int userId)
        {
            _session.Clear();
            _session.SetInt32(Constants.UserId, userId);

            return RedirectToAction("booksList", "Books");
        }

        public RedirectToActionResult LogOut()
        {
            _session.Clear();

            return RedirectToAction("Index");
        }
    }
}
