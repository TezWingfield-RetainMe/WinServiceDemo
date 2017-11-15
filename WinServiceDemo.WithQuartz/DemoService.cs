using System;
using System.Diagnostics;
using System.ServiceProcess;
using WinServiceDemo.Common;
using WinServiceDemo.WithQuartz.Quartz.Schedule;

namespace WinServiceDemo.WithQuartz
{
    public partial class DemoService : ServiceBase
    {
        EmailJobSchedule scheduler;
        public DemoService()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            try
            {
                scheduler = new EmailJobSchedule();
                scheduler.Start();

                SendEmail("Service Started",
                    "Service Successfuly Started");
            }
            catch (Exception ex)
            {
                SendEmail("Error starting service and timer",
                    ex.Message);

                EventLog.WriteEntry("Error starting service and timer..." + ex.Message);
            }
        }
        protected override void OnStop()
        {
            try
            {
                if (scheduler != null)
                {
                    scheduler.Stop();
                }

                SendEmail("Service stopped",
                    "Service Successfuly Stopped");
            }
            catch (Exception ex)
            {
                SendEmail("Error stopping timer and service",
                   ex.Message);

                EventLog.WriteEntry("Error stopping timer and service..." + ex.Message);
            }
        }
        private void SendEmail(string subject, string body)
        {
            Email.SendEmail(subject, body, "some@domain.com");
        }
    }
}
