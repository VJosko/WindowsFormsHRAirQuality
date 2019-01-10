using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace AirPollutionService
{
    public class Schedular
    {
        public void InitializeSchedular()
        {
            ISchedulerFactory schedFactory = new StdSchedulerFactory();
            IScheduler scheduler = schedFactory.GetScheduler();
            scheduler.Start();

            IJobDetail jobGetReadings = JobBuilder.Create<JobGetReadings>()
                    .WithIdentity("jobGetReadings")
                    .Build();

            ITrigger triggerJobGetReadings = TriggerBuilder.Create()
                .WithIdentity("triggerJobGetReadings")
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(12, 0))
                .Build();

            scheduler.ScheduleJob(jobGetReadings, triggerJobGetReadings);
        }
    }
}
