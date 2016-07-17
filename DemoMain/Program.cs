using Log_BLL;
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
                var attr = t.GetCustomAttribute<DescriptionAttribute>();
                Console.WriteLine(attr.Description);
                if (t.FullName == "Log_BLL.PrintDateTime")
                {
                    PrintDateTime o = Activator.CreateInstance(t) as PrintDateTime;
                    o.Print();

                    object obj = t.GetMethods()[3].Invoke(o, new[] { "hello the world!" });

                    //object obj = t.GetMethods()[1].Invoke(null, new[] { "hello the world!" });
                }


            }

            Console.ReadKey();

        }
    }


    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ParameterTypeAttribute : Attribute
    {

        public Type ParameterType
        {
            get;
            private set;
        }

        public ParameterTypeAttribute(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            this.ParameterType = type;
        }

    }
}
