using EventPlanner.Common.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Common
{
    public class EPDbContext : IdentityDbContext<User>
    {
        public EPDbContext() : base("EPDbContext")
        {
            
        }

        public static EPDbContext Create()
        {
            return new EPDbContext();
        }
    }
}
