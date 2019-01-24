using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace WindowsServiceAirQuality
{
    public class JobGetReadings : IJob
    {
        void IJob.Execute(IJobExecutionContext context)
        {
            SaveToDB();
        }
        void SaveToDB()
        {
            ServisReadingsRepository s1 = new ServisReadingsRepository();
            s1.GetReadings();
            //System.IO.File.WriteAllText(@"D:\SerivceText.txt", "SERVIS");
        }
    }
}
