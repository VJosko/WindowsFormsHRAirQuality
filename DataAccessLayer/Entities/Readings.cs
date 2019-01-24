using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Readings
    {
        public int stationId { get; set; }
        public int pollutantId { get; set; }
        public float value { get; set; }
        public float time { get; set; }
    }
}
