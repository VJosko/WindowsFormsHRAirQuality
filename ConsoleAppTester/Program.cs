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
            /*ReadingsRepository r1 = new ReadingsRepository();
            var _Readings = new List<Readings>();
            _Readings = r1.GetReadings(155, 475, "06.12.2018", "06.12.2018");
            for (int i = 0; i < _Readings.Count(); i++)
            {
                Console.WriteLine(_Readings[i].stationId + "    " + _Readings[i].pollutantId + "    " +_Readings[i].value + "    " + _Readings[i].time);
            }*/
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddMilliseconds(1470884400000);
            //r1.pushToDataBase(_Readings);
            Console.WriteLine(dateTime.ToShortDateString());
            ServisReadingsRepository s1 = new DataAccessLayer.ServisReadingsRepository();
            /*var _servisReadings = new List<ServisReadings>();
            _servisReadings = s1.GetStations();
            for(int i = 0; i < _servisReadings.Count(); i++)
            {
                Console.WriteLine(_servisReadings[i].stationId + "   " + _servisReadings[i].pollutantId);
            }*/
            //s1.GetReadings();
            Console.ReadKey();
        }
    }
}
