using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace timeSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            EntityTest entity = new EntityTest();
            entity.CustomerCreation(10);

            Console.ReadKey();
        }
    }
}
