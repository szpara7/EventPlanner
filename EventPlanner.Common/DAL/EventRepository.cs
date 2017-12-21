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
    public class EventRepository : IEventRepository
    {
        public void Add(Event obj)
        {
            using (var context = new EPDbContext())
            {
                context.Entry(obj).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Event obj)
        {
            using (var context = new EPDbContext())
            {
                obj.IsDeleted = true;
                context.Entry(obj).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public IEnumerable<Event> Find(Expression<Func<Event, bool>> predicate)
        {
            using (var context = new EPDbContext())
            {
                return context.Event.Where(predicate);
            }
        }

        public IEnumerable<Event> GetAll()
        {
            using (var context = new EPDbContext())
            {
                return context.Event.ToList();
            }
        }

        public Event GetById(Guid id)
        {
            using (var context = new EPDbContext())
            {
                return context.Event.Find(id);
            }
        }

        public void Update(Event obj)
        {
            using (var context = new EPDbContext())
            {
                context.Entry(obj).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
