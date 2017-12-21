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
    public class PostRepository : IPostRepository
    {
        public void Add(Post obj)
        {
            using (var context = new EPDbContext())
            {
                context.Entry(obj).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Post obj)
        {
            using (var context = new EPDbContext())
            {
                obj.IsDeleted = true;
                context.Entry(obj).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public IEnumerable<Post> Find(Expression<Func<Post, bool>> predicate)
        {
            using (var context = new EPDbContext())
            {
                return context.Post.Where(predicate);
            }
        }

        public IEnumerable<Post> GetAll()
        {
            using (var context = new EPDbContext())
            {
                return context.Post.ToList();
            }
        }

        public Post GetById(int id)
        {
            using (var context = new EPDbContext())
            {
                return context.Post.Find(id);
            }
        }

        public void Update(Post obj)
        {
            using (var context = new EPDbContext())
            {
                context.Entry(obj).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
