using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeSQL
{
    class ADOTest
    {
        public SqlConnection Con = new SqlConnection("data source =.; database=Netflix; integrated security=SSPI");

        
        public void Timer(int loopTime, char crud)
        {
            Stopwatch sw = Stopwatch.StartNew();

            switch (crud)
            {
                case 'c': //CREATE
                    for (int loop = 0; loop <= loopTime; loop++)
                    {
                        string sql = "INSERT INTO test (text) VALUES (@param)";
                        Query(sql, "create");

                        Console.WriteLine("Done {0}/{1}", loop, loopTime);
                    }

                    break;
                case 'r': //Read

                    for (int loop = 0; loop < loopTime; loop++)
                    {

                        SqlCommand cmd = new SqlCommand("SELECT * FROM Content", Con);
                        Con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                }
                            }
                        }
                        Con.Close();
                        
                        Console.WriteLine("{0}/{1}", loop, loopTime);

                    }
                    Console.ReadKey();

                    break;
                case 'u': //UPDATE

                    for (int loop = 0; loop <= loopTime; loop++)
                    {
                        try
                        {
                            string sql = "UPDATE test SET text=@param WHERE id = "+loop ;
                            Query(sql, "update");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Id not found" + e);
                        }
                        Console.WriteLine("Updated {0}/{1}", loop, loopTime);
                    }
                    break;

                case 'd': // DELETE

                    for (int loop = 0; loop <= loopTime; loop++)
                    {
                        try
                        {
                            string sql = "DELETE FROM test WHERE id = " + loop;
                            Query(sql, "delete");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Id not found" + e);
                        }

                        Console.WriteLine("Deleted: {0}/{1}",loop, loopTime);
                    }
                    break;

                default:
                    Console.WriteLine("Selecteer een char");
                    Console.ReadKey();
                    break;
            }

            sw.Stop();
            Console.WriteLine("Time taken Milliseconds: {0}", sw.Elapsed.TotalMilliseconds);
            Console.WriteLine("Time taken seconds: {0}", sw.Elapsed.TotalSeconds);
            Console.WriteLine("Time taken Minutes: {0}", sw.Elapsed.TotalMinutes);
            Console.WriteLine("Time taken Hours: {0}", sw.Elapsed.TotalHours);
            Console.WriteLine("Times: {0}", loopTime);
            Console.ReadKey();

            System.IO.File.WriteAllText(@"D:\C#\database2\database2\test.txt", sw.Elapsed.TotalSeconds.ToString());
        }

        public void Query(string sql, string type)
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand(sql, Con);

            switch (type)
            {
                case "update":
                    cmd.Parameters.Add("@param", SqlDbType.Text).Value = "Updated lorem ipsum";
                    break;
                case "create":
                    cmd.Parameters.Add("@param", SqlDbType.Text).Value = "Lorem upsum";
                    break;
                default:
                    cmd.Parameters.Add("@param", SqlDbType.Text).Value = "Lorem upsum";
                    break;
            }
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            Con.Close();
        }

    }
}
