using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sgprojectmanagement.Models;
using MongoDB.Driver;

namespace sgprojectmanagement.Services
{
    interface IService<TEntity> where TEntity:class
    {
        void Add(TEntity entity);
        void Delete(FilterDefinition<TEntity> filter);
        Task<TEntity> Get(FilterDefinition<TEntity> filter);
        Task<IEnumerable<TEntity>> GetAll();
        void Update(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update);
    }
}
