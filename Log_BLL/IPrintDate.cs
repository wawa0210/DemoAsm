using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log_BLL
{
    [Description("打印当前日期")]
    public interface IPrintDate : IBase
    {

        string PrintHello(string msg);

        void Hello();
    }
}
