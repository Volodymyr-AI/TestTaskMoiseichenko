using ChatDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDAL.Data
{
    public class DataSeeder
    {
        public static void SeedUsers(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                var users = new List<User>
                {
                    new User { UserName = "Forrest Gump", Email="forrest_gump@mymail.com",  },
                    new User { UserName = "Babba", Email="shrimp_boat@babba.com"},
                    new User { UserName = "Elly", Email="elly@gmail.com" }
                };
                context.AddRange(users);
                context.SaveChanges();
            }
            
        }
    }
}
