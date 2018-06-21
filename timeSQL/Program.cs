using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MongoDB.Bson;
using MongoDB.Driver;


namespace timeSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoTest test = new MongoTest();

            var Client = new MongoClient();

            var MongoDB = Client.GetDatabase("Netflix");
            var Collect = MongoDB.GetCollection<BsonDocument>("Customers");
            var document = new BsonDocument
            {
                {"name", "Yaron"},
                {"email", "Yaron@poep.com"}
            };

            Collect.InsertOneAsync(document);



            Console.ReadKey();
        }
    }
}
