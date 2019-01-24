using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace ConsoleAppTester
{
    class Program
    {
        static void Main(string[] args)
        {
            ServisReadingsRepository s1 = new ServisReadingsRepository();
            s1.GetReadings();
            //ReadingsRepository r1 = new ReadingsRepository();
            //r1.pushToDataBase(r1.GetReadings(278, 475, "01.01.2019", "15.01.2019"));
            /*DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
             dateTime = dateTime.AddMilliseconds();
             dateTime.ToShortString();*/
            Console.ReadKey();
        }
    }
}
