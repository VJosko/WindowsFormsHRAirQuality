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
            ReadingsRepository r1 = new ReadingsRepository();
            var _Readings = new List<Readings>();
            _Readings = r1.GetReadings(155, 475, "06.12.2018", "06.12.2018");
            for (int i = 0; i < _Readings.Count(); i++)
            {
                Console.WriteLine(_Readings[i].stationId + "    " + _Readings[i].pollutantId + "    " +_Readings[i].value + "    " + _Readings[i].time);
            }
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddSeconds(1544065200);
            r1.pushToDataBase(_Readings);
            Console.WriteLine(dateTime);
            Console.ReadKey();
        }
    }
}
