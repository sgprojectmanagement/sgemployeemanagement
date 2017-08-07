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
    public class EmployeeProfileUnitOfWork
    {
        private IMongoDatabase _database;
        protected EmployeeProfileRepository _EmployeeProfile;

        public EmployeeProfileUnitOfWork()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDBConectionString"];
            var client = new MongoClient(connectionString);
            var databaseName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];
            _database = client.GetDatabase(databaseName);
        }

        public EmployeeProfileRepository EmployeeProfile
        {
            get
            {
                if (_EmployeeProfile == null)
                _EmployeeProfile = new EmployeeProfileRepository(_database, "EmployeeProfile");
                return _EmployeeProfile;
            }
        }
    }
}