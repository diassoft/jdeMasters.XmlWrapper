using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jdeMasters.Components.XmlWrapper;

namespace jdeMasters.Components.XmlWrapper.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var jdeRequest = new jdeMasters.Components.XmlWrapper.XmlRequest.JDEXmlRequestCallMethod()
            {
                CallMethods = new List<JDEXmlCallMethod>()
                {
                    new JDEXmlCallMethod()
                    {
                        Name = "TestFunction",
                        Parameters = new List<Utils.JDEFunctionParameter>()
                        {
                            new Utils.JDEFunctionParameter("jdDateField", DateTime.Today)
                        }
                    }
                }
            };

            Console.WriteLine(jdeRequest.SerializeToText());

            Console.ReadLine();


        }
    }
}
