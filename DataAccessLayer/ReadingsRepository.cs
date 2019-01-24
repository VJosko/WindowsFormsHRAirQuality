using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using DataAccessLayer.Entities;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace DataAccessLayer
{
    public class ReadingsRepository
    {
        public string GetUrl(int mjernoMjestoId, int polutantId, string datumOd, string DatumDo)
        {
            string Url = "http://iszz.azo.hr/iskzl/rs/podatak/export/json?postaja=" + mjernoMjestoId + "&polutant=" + polutantId + "&tipPodatka=0&vrijemeOd=" + datumOd + "&vrijemeDo=" + DatumDo;
            return Url;
        }

        public List<Readings> GetReadings(int mjernoMjestoId, int polutantId, string datumOd, string DatumDo)
        {
            string url = GetUrl(mjernoMjestoId, polutantId, datumOd, DatumDo);
            List<Readings> _Readings = new List<Readings>();
            string Json = CallRestMethod(url);

            JArray json = JArray.Parse(Json);
            foreach (JObject item in json)
            {
                DateTime datum = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                _Readings.Add(new Readings
                {
                    stationId = mjernoMjestoId,
                    pollutantId = polutantId,
                    time = (float)item.GetValue("vrijeme"),
                    value = (float)item.GetValue("vrijednost")
                });
            }
            return _Readings;
        }

        public List<Readings> ReadReadings(DateTime from, DateTime To)
        {
            float fFrom = Convert.ToSingle(from.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds);
            float fTo = Convert.ToSingle(To.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds);
            var _readings = new List<Readings>();
            using (DbConnection connection = new SqlConnection(connectionString))
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [KvalitetaZraka_Mjeranja]";
                connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToSingle(reader["Vrijeme"]) >= fFrom && Convert.ToSingle(reader["Vrijeme"]) < fTo)
                        {
                            _readings.Add(new Readings()
                            {
                                stationId = (int)reader["MjernoMjesto"],
                                pollutantId = (int)reader["Polutant"],
                                time = Convert.ToSingle(reader["Vrijeme"]),
                                value = Convert.ToSingle(reader["Vrijednost"])
                            });
                        }
                    }
                }
            }
            return _readings;
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

        public string connectionString = "Data Source=193.198.57.183; Initial Catalog = DotNet;User ID = vjezbe; Password = vjezbe";

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

        public void pushToDataBaseMjestoPolutant(int station, int pollutant)
        {
            using (DbConnection connection = new SqlConnection(connectionString))
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO [KvalitetaZraka_Mjesta-Polutanti] (GRAD_ID, POLUTANT_ID) VALUES (" + station + "," + pollutant + ")";
                connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                }
            }
        }
    }
}
