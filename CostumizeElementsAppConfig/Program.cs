using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CostumizeElementsAppConfig.Configs;
namespace CostumizeElementsAppConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolConfig _schoolConfig = SchoolConfig.Settings;
            Console.WriteLine("School Name: {0}",_schoolConfig.Name);
            Console.WriteLine("School adress: {0}-{1}-{2}", _schoolConfig.Adress.Street,_schoolConfig.Adress.City,_schoolConfig.Adress.State);

            Console.WriteLine("Course Count: {0}", _schoolConfig.courses.Count);
            Console.WriteLine("First Course title: {0}", _schoolConfig.courses[0].Title);
            

            
            Console.WriteLine("\nDone!!!");
            Console.ReadKey();
        }
    }
}
