using Quartz;
using Quartz.Impl;

namespace WindowsServiceAirQuality
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
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(15, 46))
                .Build();

            scheduler.ScheduleJob(jobGetReadings, triggerJobGetReadings);
        }
    }
}
