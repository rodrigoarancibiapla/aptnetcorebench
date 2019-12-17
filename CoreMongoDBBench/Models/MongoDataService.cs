using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMongoDBBench.Models
{
    public class MongoDataService
    {
        private IMongoCollection<BsonDocument> collection;
        
        public MongoDataService(string connectionString, string databaseName, string collectionName)
        {
            MongoClient client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            this.collection = database.GetCollection<BsonDocument>(collectionName);
            
        }

        public string find(int number)
        {
            var filter = Builders<BsonDocument>.Filter.Gt("numEmps", number);
            var documents = collection.Find(filter).ToList<BsonDocument>();

            if (documents != null)
            {
                return documents.Take(100).ToJson();
            }
            else
            {
                return "";
            }
        }
    }
}
