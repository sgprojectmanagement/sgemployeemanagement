using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using sgprojectmanagement.Models;

namespace sgprojectmanagement.Repository
{
    public class EmployeeProjectMapRepository
    {
        private IMongoDatabase _database;
        private string _tableName;
        private IMongoCollection<EmployeeProjectMap> _collection;
        //private MongoCollectionSettings settings;
        public EmployeeProjectMapRepository(IMongoDatabase db, string tblName)
        {
            _database = db;
            _tableName = tblName;
            _collection = _database.GetCollection<EmployeeProjectMap>(_tableName);
            //_database.GetCollection<T>(tblName);
        }
        public async Task<EmployeeProjectMap> Get(string id)
        {
            var filter = Builders<EmployeeProjectMap>.Filter.Eq("EmployeeId", id);
            return await _collection.Find<EmployeeProjectMap>(filter).FirstOrDefaultAsync();
        }

        ///<summary>  
        /// Get all records   
        ///</summary>  
        ///<returns></returns>  
        public async Task<IEnumerable<EmployeeProjectMap>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        ///<summary>  
        /// Generic add method to insert enities to collection   
        ///</summary>  
        ///<param name="entity"></param>  
        public async void Add(EmployeeProjectMap entity)
        {
            await _collection.InsertOneAsync(entity);
        }
        ///<summary>  
        /// Generic delete method to delete record on the basis of id  
        ///</summary>  
        ///<param name="id"></param>  
        public async void Delete(string id)
        {
            var filter = Builders<EmployeeProjectMap>.Filter.Eq("EmployeeId", id);
            await _collection.DeleteOneAsync(filter);
        }

        public async void Update(string id, string firstName)
        {
            var filter = Builders<EmployeeProjectMap>.Filter.Eq(s => s.EmployeeId, id);
            var update = Builders<EmployeeProjectMap>.Update
                                .Set(s => s.ProjectId, firstName);
            await _collection.UpdateOneAsync(filter, update);
        }
    }
}