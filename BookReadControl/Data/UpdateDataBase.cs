using BookReadControl.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Data
{
    public class UpdateDataBase
    {
        public static void Update(AppDBContent content)
        {
            if (!content.Types.Any())
                content.Types.AddRange(Constants.Types);

            if (!content.Books.Any())
                content.Books.AddRange(Constants.Books);

            if (!content.Users.Any())
                content.Users.AddRange(Constants.Users);

            content.SaveChanges();
        }
    }
}
