using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudGenerator
{
    class Program 
    {
        static void Main(string[] args)
        {
            Home home = new Home();
            home.GetColumnListForSpecifiedObject();
            Console.ReadKey();

        }

      
    }
}
