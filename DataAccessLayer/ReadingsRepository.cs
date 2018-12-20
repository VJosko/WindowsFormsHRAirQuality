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

        public List<Readings> GetReadings(string url)
        {
            List<Readings> _Readings = new List<Readings>();
            string Json = CallRestMethod(url);

            JArray json = JArray.Parse(Json);
            foreach (JObject item in json)
            {
                _Readings.Add(new Readings
                {
                    time = (float)item.GetValue("vrijeme"),
                    value = (float)item.GetValue("vrijednost")
                });
            }
            return _Readings;
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
    }
}
