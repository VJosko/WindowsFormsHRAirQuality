using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using DataAccessLayer.Entities;

namespace DataAccessLayer
{
    public class PollutantRepository
    {
        public string connectionString = "Data Source=193.198.57.183; Initial Catalog = DotNet;User ID = vjezbe; Password = vjezbe";

        public List<Pollutant> GetPollutant()
        {
            var Pollutants = new List<Pollutant>();
            using (DbConnection connection = new SqlConnection(connectionString))
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM KvalitetaZraka_Polutanti";
                connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pollutants.Add(new Pollutant()
                        {
                            id = (int)reader["ID"],
                            name = (string)reader["NAZIV"]
                        });
                    }
                }
            }
            return Pollutants;
        }
        public List<string> GetPollutantNames()
        {
            var names = new List<string>();
            var pollutant = new List<Pollutant>();
            pollutant = GetPollutant();
            names = pollutant.Where(x => !string.IsNullOrEmpty(x.name)).Select(x => x.name).ToList();
            return names;
        }
    }
}
