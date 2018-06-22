using System;
using System.Collections.Generic;
using System.Diagnostics;
using MongoDB.Bson;
using MongoDB.Driver;

namespace timeSQL
{
    class MongoTest
    {
        private const string ConnectionString = "mongodb://localhost:27017";

        private readonly MongoClient _client;


        public MongoTest()
        {
            Stopwatch sw = Stopwatch.StartNew();
            int loopTime = 1;
            _client = new MongoClient(ConnectionString);

            //Insert(loopTime);
            Delete(1);   

            sw.Stop();
            Console.WriteLine("Time taken Milliseconds: {0}", sw.Elapsed.TotalMilliseconds);
            Console.WriteLine("Time taken seconds: {0}", sw.Elapsed.TotalSeconds);
            Console.WriteLine("Time taken Minutes: {0}", sw.Elapsed.TotalMinutes);
            Console.WriteLine("Time taken Hours: {0}", sw.Elapsed.TotalHours);
            Console.WriteLine("Times: {0}", loopTime);
            Console.ReadKey();
        }


        public void Insert(int timer)
        {
            for (int i = 0; i <= timer; i++)
            {
                var database = _client.GetDatabase("Netflix");
                var collection = database.GetCollection<BsonDocument>("Customers");

                var mongoConstumer = new MongoConstumer
                {
                    SomeId = 1,
                    Name = "yaron",
                    Email = "yaron@hoitmail.com",
                    SomeTableList = new List<MongoConstumer.SomeTable>()
                };

                var someTable = new MongoConstumer.SomeTable
                {
                    SomeId = 2,
                    Name = "Peter",
                    Email = "Peter@hotmail.com"
                };
                mongoConstumer.SomeTableList.Add(someTable);



                var customer = new BsonDocument();

                foreach (var rowSomeTable in mongoConstumer.SomeTableList)
                {
                    customer.Add(new BsonElement("table_id", mongoConstumer.SomeId), new BsonElement("name", mongoConstumer.Name), new BsonElement("email", rowSomeTable.Name));
                }



                collection.InsertOneAsync(customer);

                Console.WriteLine("{0}/{1}", i, timer);
            }

        }

        public void Update(int timer)
        {


            for (int i = 0; i <= timer; i++)
            {
                var database = _client.GetDatabase("Netflix");
                var collection = database.GetCollection<BsonDocument>("Customers");

                var updateCustomerName = new BsonElement("name", "yaron");

                var updatePCostumerDetails =
                    new BsonDocument { updateCustomerName, new BsonElement("email", "yaron@hotmail.com") };

                var findCustomer = new BsonDocument(new BsonElement("name", "yaron"));
                var updateCustomer = collection.FindOneAndReplace(findCustomer, updatePCostumerDetails);
                Console.WriteLine("{0}/{1}", i, timer);
            }
        }

        public void Delete(int timer)
        {
            for (int i = 0; i <= timer; i++)
            {
                var database = _client.GetDatabase("Netflix");
                var collection = database.GetCollection<BsonDocument>("Customers");

                var findCustomer = new BsonDocument(new BsonElement("name", "yaron"));

                collection.FindOneAndDelete(findCustomer);
                Console.WriteLine("{0}/{1}", i, timer);

            }
        }


        public void View(int timer)
        {
            for (int i = 0; i <= timer; i++)
            {
                var database = _client.GetDatabase("Netflix");
                var collection = database.GetCollection<BsonDocument>("Customers");

                var allUsers = collection.Find(new BsonDocument()).ToList();

                foreach (var allUser in allUsers)
                {
                    Console.WriteLine(allUser);
                }

                Console.WriteLine("{0}/{1}", i, timer);
            }
        }

    }

    public class MongoConstumer
    {
        public int SomeId { get; set; }

        public String Name { get; set; }

        public String Email { get; set; }

        public List<SomeTable> SomeTableList { get; set; }

        public class SomeTable
        {
            public int SomeId { get; set; }

            public String Name { get; set; }

            public String Email { get; set; }
        }
    }
}


