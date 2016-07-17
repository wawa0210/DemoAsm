using Log_BLL;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoMain
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintDateTime printDateTime = new PrintDateTime();
            string dllPath = AppDomain.CurrentDomain.BaseDirectory + "Log_BLL.dll";
            var asm = Assembly.LoadFrom(dllPath);

            Type[] arrayType = asm.GetTypes();

            foreach (Type t in arrayType)
            {

                // 获得类的注释
                //var attr = t.GetCustomAttribute<DescriptionAttribute>();
                //Console.WriteLine(attr.Description);
                if (t.FullName == "Log_BLL.PrintDateTime")
                {
                    // Grab the Scheduler instance from the Factory 
                    IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();

                    // and start it off
                    scheduler.Start();

                    // define the job and tie it to our HelloJob class
                    IJobDetail job = JobBuilder.Create(t)
                        .WithIdentity("job1", "group1").UsingJobData("hello", "hello the world!")
                        .Build();

                    // Trigger the job to run now, and then repeat every 10 seconds
                    ITrigger trigger = TriggerBuilder.Create()
                        .WithIdentity("trigger1", "group1")
                        .StartNow().WithCronSchedule("0/1 * * * * ?")
                        .Build();

                    // Tell quartz to schedule the job using our trigger
                    scheduler.ScheduleJob(job, trigger);
                }
            }
            Console.ReadKey();
        }
    }
}
