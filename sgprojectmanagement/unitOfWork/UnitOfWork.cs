using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using sgprojectmanagement.Repository;
using sgprojectmanagement.Models;
using System.Configuration;

namespace sgprojectmanagement.unitOfWork
{
    public class UnitOfWork<TEntity> where TEntity:class
    {
        private IMongoDatabase _database;
        protected Repository<TEntity> _EmployeeProfile;

        public UnitOfWork()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDBConectionString"];
            var client = new MongoClient(connectionString);
            var databaseName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];
            _database = client.GetDatabase(databaseName);
        }

        public Repository<TEntity> Access
        {
            get
            {
                if (_EmployeeProfile == null)
                    _EmployeeProfile = new Repository.Repository<TEntity>(_database, "EmployeeProfile");
                return _EmployeeProfile;
            }
        }
    }
}