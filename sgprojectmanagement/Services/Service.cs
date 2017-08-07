using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sgprojectmanagement.unitOfWork;
using sgprojectmanagement.Models;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace sgprojectmanagement.Services
{
    public class Service<TEntity> :IService<TEntity> where TEntity:class
    {
        protected readonly UnitOfWork<TEntity> _employeeProfileUnitOfWork;
        public Service()
        {
            _employeeProfileUnitOfWork = new UnitOfWork<TEntity>();
        }

        public  void Add(TEntity entity)
        {
            
            _employeeProfileUnitOfWork.Access.Add(entity);
        }

        public Task<TEntity> Get(FilterDefinition<TEntity> filter)
        {
            
            return _employeeProfileUnitOfWork.Access.Get(filter);
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            return _employeeProfileUnitOfWork.Access.GetAll();
        }

        public void Delete(FilterDefinition<TEntity> filter)
        {
             _employeeProfileUnitOfWork.Access.Delete(filter);
        }

        public void Update(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update)
        {
            _employeeProfileUnitOfWork.Access.Update(filter, update);
        }
    }
}