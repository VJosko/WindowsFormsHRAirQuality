using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using DataAccessLayer.Entities;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace DataAccessLayer
{
    public class ServisReadingsRepository
    {
        public string connectionString = "Data Source=193.198.57.183; Initial Catalog = DotNet;User ID = vjezbe; Password = vjezbe";

        public List<ServisReadings> GetStations()
        {
            var Stations = new List<ServisReadings>();
            using (DbConnection connection = new SqlConnection(connectionString))
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [KvalitetaZraka_Mjesta-Polutanti]";
                connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Stations.Add(new ServisReadings()
                        {
                            stationId = (int)reader["GRAD_ID"],
                            pollutantId = (int)reader["POLUTANT_ID"]
                        });
                    }
                }
            }
            return Stations;
        }

        public List<Readings> GetReadings()
        {
            var _Readings = new List<Readings>();
            var stations = new List<ServisReadings>();
            ServisReadingsRepository s1 = new ServisReadingsRepository();
            stations = s1.GetStations();
            for (int i = 0; i < stations.Count(); i++)
            {
                string Url = "http://iszz.azo.hr/iskzl/rs/podatak/export/json?postaja=" + stations[i].stationId + "&polutant=" + stations[i].pollutantId + "&tipPodatka=0&vrijemeOd=03.01.2019&vrijemeDo=03.01.2019";
                string Json = CallRestMethod(Url);
                JArray json = JArray.Parse(Json);
                foreach (JObject item in json)
                {
                    float time = (float)item.GetValue("vrijeme");
                    DateTime datum = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    datum = datum.AddMilliseconds(time);
                    _Readings.Add(new Readings
                    {
                        stationId = stations[i].stationId,
                        pollutantId = stations[i].pollutantId,
                        time = datum,
                        value = (float)item.GetValue("vrijednost")
                    });
                }
            }
            return (_Readings);
        }

        public static string CallRestMethod(string url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            return result;
        }

        public void pushToDataBase(List<Readings> readings)
        {
            for (int i = 0; i < readings.Count(); i++)
            {
                using (DbConnection connection = new SqlConnection(connectionString))
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO KvalitetaZraka_Mjeranja (MjernoMjesto, Polutant, Vrijednost, Vrijeme) VALUES (" + readings[i].stationId + "," + readings[i].pollutantId + "," + readings[i].value + "," + readings[i].time + ")";
                    connection.Open();
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                    }
                }
            }
        }
    }
}
