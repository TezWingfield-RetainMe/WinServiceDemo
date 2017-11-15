using Quartz;
using Quartz.Impl;
using WinServiceDemo.WithQuartz.Quartz.Jobs;

namespace WinServiceDemo.WithQuartz.Quartz.Schedule
{
    public class EmailJobSchedule
    {
        public void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<EmailJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                   .WithSimpleSchedule(a => a.WithIntervalInMinutes(30).RepeatForever())
                   .Build();

            scheduler.ScheduleJob(job, trigger);
        }

        public void Stop()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Shutdown();
        }
    }
}
