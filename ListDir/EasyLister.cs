using System;
using System.IO;

namespace ListDir
{
    public class EasyLister
    {
        public void PrintDir(string path)
        {
            foreach (var d in Directory.GetDirectories(path))
            {
                Console.WriteLine(" - " + d);

                foreach (var item in Directory.GetFiles(d))
                {
                    Console.WriteLine(" - " + Path.GetFileName(item) + " posledni modifikace: "+ File.GetLastWriteTime(item));
                }
                PrintDir(d);
            }
        }
    }
}