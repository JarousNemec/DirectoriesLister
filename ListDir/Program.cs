using System;
using System.IO;

namespace ListDir
{
    class Program
    {
        static void Main(string[] args)
        {
            var hardLister = new HardLister();
            var easyLister = new EasyLister();

            DateTime start = DateTime.Now;
            hardLister.PrintDirectory(Directory.GetCurrentDirectory());
            DateTime end = DateTime.Now;
            long cycleDifferent = end.Ticks - start.Ticks;    

            start = DateTime.Now;
            easyLister.PrintDir(Directory.GetCurrentDirectory());
            end = DateTime.Now;
            long recurseDifferent = end.Ticks - start.Ticks;
            Console.WriteLine();
            Console.WriteLine("recurse - "+recurseDifferent);
            Console.WriteLine("cycle   - "+cycleDifferent);
            Console.ReadKey();
        }        
    }
}
