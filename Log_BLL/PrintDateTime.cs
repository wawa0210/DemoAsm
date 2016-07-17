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
            Console.WriteLine("task excute，jobSays:hello the world!");
            Thread t = new Thread(new ThreadStart(Hello));
            t.Start();
        }

        public void Hello()
        {
            Console.WriteLine("task excute");
        }
    }
}
