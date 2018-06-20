using System;
using System.Diagnostics;

namespace ado
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSpeed test = new TestSpeed();

            test.LoopTime(3000);

        }
    }
}
