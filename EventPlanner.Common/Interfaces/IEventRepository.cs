using EventPlanner.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Common.Interfaces
{
    public interface IEventRepository 
    {
        IEnumerable<Event> GetAll();
        Event GetById(Guid id);
        IEnumerable<Event> Find(Expression<Func<Event, bool>> predicate);
        void Add(Event obj);
        void Delete(Event obj);
        void Update(Event obj);
    }
}
