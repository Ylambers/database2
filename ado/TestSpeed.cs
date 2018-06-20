using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ado
{
    class TestSpeed
    {
        public TestSpeed()
        {

        }

        public void LoopTime(int time)
        {

            Stopwatch sw = Stopwatch.StartNew();

            for (int index = 0; index < time; index++)
            {
                Console.Write("");
            }

            sw.Stop();
            
            Console.WriteLine(sw.ElapsedMilliseconds + " ms");
            Console.ReadKey();
        }
    }
}
