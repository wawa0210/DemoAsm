
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuartzDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string dllPath = AppDomain.CurrentDomain.BaseDirectory + "Log_BLL.dll";
            var asm = Assembly.LoadFrom(dllPath);

            Type[] arrayType = asm.GetTypes();

            foreach (Type t in arrayType)
            {
                if (t.IsClass && t.FullName != "Log_BLL.JobExec")
                {
                    var attr = t.GetCustomAttribute<DescriptionAttribute>();
                    Console.WriteLine(attr.Description);
                    if (t.FullName == "Log_BLL.JobExec")
                    {
                        //从工厂中获取一个调度器实例化
                        IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();

                        scheduler.Start();       //开启调度器

                        //==========例子2 (执行时 作业数据传递，时间表达式使用)===========

                        IJobDetail job2 = JobBuilder.Create(t)
                                                    .WithIdentity("myJob", "group1")
                                                    .UsingJobData("jobSays", "Hello World!")
                                                    .Build();


                        ITrigger trigger2 = TriggerBuilder.Create()
                                                    .WithIdentity("mytrigger", "group1")
                                                    .StartNow()
                                                    .WithCronSchedule("/1 * * ? * *")    //时间表达式，5秒一次     
                                                    .Build();


                        scheduler.ScheduleJob(job2, trigger2);
                    }
                }
            }




        }
    }

    /// <summary>
    /// 作业
    /// </summary>
    public class HelloJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("作业执行!");
        }
    }

    public class DumbJob : IJob
    {
        /// <summary>
        ///  context 可以获取当前Job的各种状态。
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {

            JobDataMap dataMap = context.JobDetail.JobDataMap;

            string content = dataMap.GetString("jobSays");

            Console.WriteLine("作业执行，jobSays:" + content);
        }
    }
}
