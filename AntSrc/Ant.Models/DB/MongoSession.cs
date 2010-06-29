using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Norm;
using Ant.Models.Questions;
using Norm.Responses;
using Norm.Configuration;

namespace Ant.Models.DB
{
    public class MongoSession : IDisposable
    {

        private readonly Mongo _provider;

        public MongoSession()
        {
            _provider = Mongo.Create("mongodb://127.0.0.1/NormTests?strict=false");
        }

        public MongoDatabase DB { get { return this._provider.Database; } }

        public IQueryable<Question> Questions
        {
            get { return _provider.GetCollection<Question>().AsQueryable(); }
        }

        public void Dispose()
        {
            _provider.Dispose();
        }

        public void Add<T>(T item) where T : class, new()
        {
            _provider.Database.GetCollection<T>().Insert(item);
        }

        public void Update<T>(T item) where T : class, new()
        {
            _provider.Database.GetCollection<T>().Save(item);
        }

        public void Delete<T>(T item) where T : class, new()
        {
            _provider.Database.GetCollection<T>().Delete(item);
        }

        //public void Drop<T>()
        //{
        //    _provider.Database.DropCollection(MongoConfiguration.GetCollectionName(typeof(T)));
        //}
    }
}
