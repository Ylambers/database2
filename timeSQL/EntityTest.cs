using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;
using System.Runtime.Remoting.Contexts;

namespace timeSQL
{
    class EntityTest
    {
        public void CustomerCreation(int times) //Create user
        {
            Stopwatch sw = Stopwatch.StartNew();

            using (var db = new CustomerContext())
            {

                for (int i = 0; i <= times; i++)
                {
                    var customer = new Customer() { Name = "Yaron Lambers", Email = "Yaronlambers@gmail.com", password = "Geheim", blocked = 1, subscription = 1 };
                    db.Customers.Add(customer);
                    db.SaveChanges();

                    Console.WriteLine("{0}/{1}", i, times);
                }
                
            }
            sw.Stop();
            Console.WriteLine("Time taken Milliseconds: {0}", sw.Elapsed.TotalMilliseconds);
            Console.WriteLine("Time taken seconds: {0}", sw.Elapsed.TotalSeconds);
            Console.WriteLine("Time taken seconds: {0}", sw.Elapsed.TotalMinutes);
            Console.WriteLine("Time taken Hours: {0}", sw.Elapsed.TotalHours);
            Console.ReadKey();
        }
    }

    class Customer
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public int blocked { get; set; }
        public int subscription { get; set; }


        public virtual List<Blocked> Blockeds { get; set; }
        public virtual List<Subscription> Subscriptions { get; set; }

        public Customer()
        {
            this.Subscriptions = new List<Subscription>();
            this.Blockeds = new List<Blocked>();
        }
    }

    class Blocked
    {
        public int BlockedId { get; set; }
        public DateTime date { get; set; }
        public int CustomerId { get; set; }
        public DateTime BlockedTill { get; set; }
        public int blocked { get; set; }
    }

    class Subscription
    {
        public int SubscriptionId { get; set; }
        public int Cost { get; set; }
        public int Quality { get; set; }
    }

    class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Blocked> Blockeds { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
