using EventPlanner.Common.Interfaces;
using EventPlanner.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Common.DAL
{
    public class UserRepository : IUserRepository
    {
        public void Update(User user)
        {
            using (var context = new EPDbContext())
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
