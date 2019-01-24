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
        StationRepository _stationRepository = new StationRepository();
        ReadingsRepository _readingsRepository = new ReadingsRepository();
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

        public List<string> GetPollutantBase(string mjernoMjesto)
        {
            var stations = _stationRepository.GetStations();
            int nMjernoMjesto = 0;
            for(int i  = 0; i < stations.Count(); i++)
            {
                if(stations[i].name == mjernoMjesto)
                {
                    nMjernoMjesto = stations[i].id;
                }
            }
            var pollutantsId = new List<int>();
            using (DbConnection connection = new SqlConnection(connectionString))
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [KvalitetaZraka_Mjesta-Polutanti]";
                connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pollutantsId.Add((int)reader["POLUTANT_ID"]);
                        pollutantsId.Add((int)reader["GRAD_ID"]);
                    }
                }
            }
            List<Pollutant> Pollutants = GetPollutant();
            var pollutantsBase = new List<string>();
            for (int i = 0; i < Pollutants.Count(); i++)
            {
                for (int j = 0; j < pollutantsId.Count(); j+=2)
                {
                    for (int l = 0; l < stations.Count(); l++)
                    {
                        if (Pollutants[i].id == pollutantsId[j] && nMjernoMjesto == pollutantsId[j+1])
                        {
                            bool bIma = false;
                            for(int k = 0; k < pollutantsBase.Count(); k++)
                            {
                                if(pollutantsBase[k] == Pollutants[i].name)
                                {
                                    bIma = true;
                                }
                            }
                            if (bIma == false)
                            {
                                pollutantsBase.Add(Pollutants[i].name);
                            }
                        }
                    }
                }
            }

            return pollutantsBase;
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
