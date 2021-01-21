using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = ConfigurationManager.AppSettings["SQLiteConnectionString"];
            Console.WriteLine(text);
            Console.Read();
        }
    }
}
