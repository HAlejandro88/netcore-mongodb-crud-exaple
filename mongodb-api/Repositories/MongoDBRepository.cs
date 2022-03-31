using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mongodb_api.Repositories
{
    public class MongoDBRepository
    {
        public MongoClient client; // este es el provider

        public IMongoDatabase db;

        public MongoDBRepository()
        {
            client = new MongoClient("mongodb://localhost:27017");
            // crear l base de datos

            db = client.GetDatabase("Inventory");
        }
    }
}
