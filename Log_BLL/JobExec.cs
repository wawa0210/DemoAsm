using Quartz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log_BLL
{
    public class JobExec : IJob
    {
        [Description("Quartz.net exec class")]
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("hello the world!");
        }
    }
}
