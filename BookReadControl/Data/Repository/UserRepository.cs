using BookReadControl.Data.Interfaces;
using BookReadControl.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Data.Repository
{
    public class UserRepository : IUser
    {
        private readonly AppDBContent appDBContent;

        public UserRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public User GetCurentUser(IServiceProvider provider)
        {
            ISession session = provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //Если пользователь не зарегистрирован "создаем нового"
            int userId = session.GetInt32(Constants.UserId) ?? 1;
            return GetUser(userId);
        }

        public User GetUser(int id)
        {
            return appDBContent.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
