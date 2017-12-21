using EventPlanner.Common.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public DbSet<DatePreference> DatePreference { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<EventUserGroup> EventUserGroup { get; set; }
        public DbSet<Post> Post { get; set; }

        public static EPDbContext Create()
        {
            return new EPDbContext();
        }
    }
}

