﻿using BookReadControl.Data.Interfaces;
using BookReadControl.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Data.mocks
{
    public class MockUser : IUser
    {
        //Таблица в БД
        private IEnumerable<User> Users => Constants.Users;

        public User GetUser(int id)
        {
            return Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public User GetCurentUser(IServiceProvider provider)
        {
            ISession session = provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //Если пользователь не зарегистрирован "создаем нового"
            int userId = session.GetInt32(Constants.UserId) ?? 0;
            return GetUser(userId);
        }
    }
}
