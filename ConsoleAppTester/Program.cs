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
            _Readings = r1.GetReadings("http://iszz.azo.hr/iskzl/rs/podatak/export/json?postaja=155&polutant=1&tipPodatka=4&vrijemeOd=04.12.2018&vrijemeDo=18.12.2018");
            for (int i = 0; i < _Readings.Count(); i++)
            {
                Console.WriteLine(_Readings[i].value + "    " + _Readings[i].time);
            }
            Console.ReadKey();
        }
    }
}
