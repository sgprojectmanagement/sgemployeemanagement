using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace sgprojectmanagement.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        private IMongoDatabase _database;
        private string _tableName;
        private IMongoCollection<TEntity> _collection;

        public Repository(IMongoDatabase db, string tblName)
        {
            _database = db;
            _tableName = tblName;
            _collection = _database.GetCollection<TEntity>(_tableName);
        }

        public void Add(TEntity T)
        {
            _collection.InsertOneAsync(T);
        }
        public Task<TEntity> Get(string filter)
        {
            return _collection.Find(filter).FirstOrDefaultAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _collection.Find(_ => true).ToEnumerable<TEntity>();
        }
        public void Remove(string filter)
        {
            _collection.DeleteOneAsync(filter);
        }
        public void FindAndUpdate(Expression<Func<TEntity, bool>> predicate,UpdateDefinition<TEntity> update, FindOneAndUpdateOptions<TEntity> options)
        {
            _collection.FindOneAndUpdate(predicate, update, options);
        }
    }
}