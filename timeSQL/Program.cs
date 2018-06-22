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

            MongoTest mongo = new MongoTest();
            

            ADOTest ado = new ADOTest();
            ado.Timer(1, 'd');


            EntityTest entity = new EntityTest();
            entity.CustomerUpdate(1000);
            
        }
        
    }
}
