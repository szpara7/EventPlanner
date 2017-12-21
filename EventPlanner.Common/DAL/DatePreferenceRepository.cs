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
    public class DatePreferenceRepository : IDatePreferenceRepository
    {
        public void Add(DatePreference obj)
        {
            using (var context = new EPDbContext())
            {
                context.Entry(obj).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(DatePreference obj)
        {
            using (var context = new EPDbContext())
            {
                context.Entry(obj).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public IEnumerable<DatePreference> GetAll()
        {
            using (var context = new EPDbContext())
            {
                return context.DatePreference.ToList();
            }
        }

        public DatePreference GetById(int id)
        {
            using (var context = new EPDbContext())
            {
                return context.DatePreference.Find(id);
            }
        }

        public void Update(DatePreference obj)
        {
            using (var context = new EPDbContext())
            {
                context.Entry(obj).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public IEnumerable<DatePreference> Find(Expression<Func<DatePreference, bool>> predicate)
        {
            using (var context = new EPDbContext())
            {
                return context.DatePreference.Where(predicate);
            }
        }
    }
}
