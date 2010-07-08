using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Norm;
using Norm.Responses;
using Norm.Configuration;
using Norm.Collections;
using System.Configuration;

namespace Ant.DB
{
    public class MongoSession : IDisposable
    {

        private readonly Mongo _provider;
        static MongoSession()
        {
            string key = ConfigurationManager.AppSettings["MongoDBConnection"];
            ConnectionString = ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
        static readonly string ConnectionString;

        public MongoSession()
        {
            _provider = Mongo.Create(ConnectionString);
        }

        public MongoDatabase DB { get { return this._provider.Database; } }

        public IQueryable<T> Query<T>()
        {
            return _provider.GetCollection<T>().AsQueryable();
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return _provider.GetCollection<T>();
        }

        public void Dispose()
        {
            _provider.Dispose();
        }

        public void Add<T>(T item) where T : class, new()
        {
            _provider.Database.GetCollection<T>().Insert(item);
        }

        public void Upsert<T>(T item) where T : class, new()
        {
            _provider.Database.GetCollection<T>().Save(item);
        }

        public void Delete<T>(T item) where T : class, new()
        {
            _provider.Database.GetCollection<T>().Delete(item);
        }

        public void Drop<T>()
        {
            _provider.Database.DropCollection(_provider.Database.GetCollection<T>().FullyQualifiedName);
        }
    }
}
