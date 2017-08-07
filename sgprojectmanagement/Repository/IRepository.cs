using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace sgprojectmanagement.Repository
{
    interface IRepository<TEntity> where TEntity:class
    {
        void Add(TEntity T);
        Task<TEntity> Get(string filter);
        IEnumerable<TEntity> GetAll();
        void Remove(string filter);
        void FindAndUpdate(Expression<Func<TEntity, bool>> predicate, UpdateDefinition<TEntity> update, FindOneAndUpdateOptions<TEntity> options);

    }
}
