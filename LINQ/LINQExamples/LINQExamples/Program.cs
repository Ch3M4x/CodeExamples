using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using System.Configuration;

namespace LINQExamples
{
    class Program
    {
        private static Business BUSINESS;

        static void Main(string[] args)
        {
            Console.WriteLine("Initializing application...");

            BUSINESS = new Business(ConfigurationManager.ConnectionStrings["mainDatabase"].ConnectionString);
            //BUSINESS.processExamplePersons();
            //BUSINESS.processExamplePersons2();
            //BUSINESS.processExamplePersons3();
            //BUSINESS.processExamplePersons4();

            Console.WriteLine("Application terminated. Press any key to finish...");
            Console.ReadLine();
        }
    }
}
