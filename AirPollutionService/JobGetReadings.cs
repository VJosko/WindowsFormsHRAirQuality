using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace AirPollutionService
{
    public class JobGetReadings: IJob
    {
        void IJob.Execute(IJobExecutionContext context)
        {
            SaveToDB();
        }

        void SaveToDB()
        {
            ServisReadingsRepository s1 = new ServisReadingsRepository();
            var readings = s1.GetReadings();

                s1.pushToDataBase(readings);
        }
    }
}
