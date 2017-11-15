using Quartz;
using System;
using WinServiceDemo.Common;

namespace WinServiceDemo.WithQuartz.Quartz.Jobs
{
    public class EmailJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            //Job to do on each cycle
            Email.SendEmail("subject",
                            "Sent from job cycle (runs every 30mins): " + DateTime.Now.ToShortDateString(),
                            "to-email");
        }
    }
}
