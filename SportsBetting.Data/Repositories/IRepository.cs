using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SportsBetting.Data.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll(
             Expression<Func<T, bool>> filter = null,
             Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
             string includeProperties = "");//

        T FindById(object id);//

        void Add(T entity);//

        void Update(T entity);//

        void Remove(T entity);//

        void RemoveById(object id);//
    }
}
