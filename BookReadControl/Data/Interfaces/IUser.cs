using BookReadControl.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Data.Interfaces
{
    public interface IUser
    {
        User GetUser(int id);

        User GetCurentUser(IServiceProvider provider);
    }
}
