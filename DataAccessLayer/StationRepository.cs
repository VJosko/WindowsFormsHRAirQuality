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
    public class StationRepository
    {
        public string connectionString = "Data Source=193.198.57.183; Initial Catalog = DotNet;User ID = vjezbe; Password = vjezbe";

        public List<Station> GetStations()
        {
            var Stations = new List<Station>();
            using (DbConnection connection = new SqlConnection(connectionString))
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM KvalitetaZraka_MjernaMjesta";
                connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Stations.Add(new Station()
                        {
                            id = (int)reader["ID"],
                            name = (string)reader["NAZIV"]
                        });
                    }
                }
            }
            return Stations;
        }
    }
}
