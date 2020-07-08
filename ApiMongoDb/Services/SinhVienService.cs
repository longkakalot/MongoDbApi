using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMongoDb.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace ApiMongoDb.Services
{
    public class SinhVienService
    {
        private readonly IMongoCollection<SinhVien> _mongoCollection;

        public SinhVienService(ISinhVienDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _mongoCollection = database.GetCollection<SinhVien>(settings.SinhVienCollectionName);
        }

        public List<SinhVien> GetAll() => _mongoCollection.Find(sinhVien => true).ToList();

        public SinhVien GetById(string id) =>
            _mongoCollection.Find<SinhVien>(sinhVienId => sinhVienId.ID == id).FirstOrDefault();

        public List<SinhVien> GetSinhVienMath(string math, string viet)
        {
            var dbClient = new MongoClient("mongodb://localhost:27017");

            IMongoDatabase db = dbClient.GetDatabase("SinhVienDb");
            var command = new BsonDocument { { "dbstats", 1 } };
            var result1 = db.RunCommand<BsonDocument>(command);

            var cars = db.GetCollection<BsonDocument>("SinhVien");

            var filter = Builders<BsonDocument>.Filter.Eq("math", math);

            //var filter1 = new BsonDocument("Math", "1");
            //var filter1 = new BsonDocument("Math", new BsonDocument("$eq", "1"));
            var filter1 = "{ Math: {'$gt': '1'}}";
            //var filter1 = new BsonDocument("math", new BsonDocument("$eq", 1));
            var doc = cars.Find(filter1).ToList();

            var result = _mongoCollection.Find(m => m.Math == math && m.Viet == viet).ToList();
            //var result2 = _mongoCollection.Find(new BsonDocument()).ToList();
            //var filter = Builders<BsonDocument>.Filter.Eq("math", math);
            var result11 = _mongoCollection.Find(filter1).ToList();

            //var result1 = _mongoCollection.Find(new BsonDocument("$where", "this.math == '" + math + "'")).ToList();
            //var result1 = _mongoCollection.Find(new BsonDocument("math", new BsonObjectId("1"))).ToList();
            return result;
        }

        public List<SinhVien> GetSinhVienMath1(SinhVien sv)
        {
            var result = _mongoCollection.Find(m => m.Math == sv.Math && m.Viet == sv.Viet).ToList();
            var filter = Builders<BsonDocument>.Filter.Eq("math", sv.Math);
            
            //var result1 = _mongoCollection.Find(new BsonDocument("$where", "this.math == '" + math + "'")).ToList();
            return result;
        }

    }
}
