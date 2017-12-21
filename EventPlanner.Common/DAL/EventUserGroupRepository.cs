using EventPlanner.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPlanner.Common.Models;
using System.Linq.Expressions;
using System.Data.Entity;

namespace EventPlanner.Common.DAL
{
    public class EventUserGroupRepository : IEventUserGroupRepository
    {
        public void Add(EventUserGroup obj)
        {
            using (var context = new EPDbContext())
            {
                context.Entry(obj).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(EventUserGroup obj)
        {
            using (var context = new EPDbContext())
            {
                context.Entry(obj).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public IEnumerable<EventUserGroup> Find(Expression<Func<EventUserGroup, bool>> predicate)
        {
            using (var context = new EPDbContext())
            {
                return context.EventUserGroup.Where(predicate);
            }
        }

        public IEnumerable<EventUserGroup> GetAll()
        {
            using (var context = new EPDbContext())
            {
                return context.EventUserGroup.ToList();
            }
        }

        public EventUserGroup GetById(int id)
        {
            using (var context = new EPDbContext())
            {
                return context.EventUserGroup.Find(id);
            }
        }

        public void Update(EventUserGroup obj)
        {
            using (var context = new EPDbContext())
            {
                context.Entry(obj).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
