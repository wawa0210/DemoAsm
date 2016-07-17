//------------------------------------------------------------------------------------------------
//
//
//         All rights reserved
//
//		   filename:PrintDateTime
//		   desciption:
//
//		   created by 张潇 at 2016/7/13 21:59:30
//
//------------------------------------------------------------------------------------------------

using Quartz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Log_BLL
{
    [Description("打印当前日期")]
    public class PrintDateTime : IJob
    {
        public void Print()
        {
            Console.WriteLine(DateTime.Now.ToString());
        }

        public static string Print(string msg)
        {
            return msg + ">>>>" + DateTime.Now.ToString();
        }

        public string PrintHello(string msg)
        {
            return msg + ">>!!!!>>" + DateTime.Now.ToString();
        }

        public void Execute(IJobExecutionContext context)
        {
            JobKey key = context.JobDetail.Key;

            JobDataMap dataMap = context.JobDetail.JobDataMap;

            string jobSays = dataMap.GetString("hello");

            Console.WriteLine("task excute |||" + jobSays);

        }

        public void Hello()
        {
            Console.WriteLine("task excute");
        }
    }
}
