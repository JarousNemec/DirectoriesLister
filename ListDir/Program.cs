﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ListDir
{
    class Program
    {
        static void Main(string[] args)
        {
            var hardLister = new HardLister();
            hardLister.PrintDirectory(Directory.GetCurrentDirectory());
            
            Console.ReadKey();
        }

        
    }
}
