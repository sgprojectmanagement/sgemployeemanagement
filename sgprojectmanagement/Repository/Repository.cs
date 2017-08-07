using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace sgprojectmanagement.Repository
{
    public class Repository<TEntity>
    {

        private IMongoDatabase _database;
        private string _tableName;
        private IMongoCollection<TEntity> _collection;


        public Repository(IMongoDatabase db, string tblName)
        {
            _database = db;
            _tableName = tblName;
            _collection = _database.GetCollection<TEntity>(tblName);
        }
        public async Task<TEntity> Get(FilterDefinition<TEntity> filter)
        {

            return await _collection.Find<TEntity>(filter).FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var some= _collection.Find(_ => true).ToListAsync();
            return await some;
        }


        public async void Add(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async void Delete(FilterDefinition<TEntity> filter)
        {

            await _collection.DeleteOneAsync(filter);
        }

        public async void Update(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update)
        {
            await _collection.UpdateOneAsync(filter, update);
        }
    }
}

