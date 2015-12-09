using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainigTracker.Service
{
    class FactoryConcreteParser
    {
        public static List<IXMLConcreteParser> GetParsers()
        {
            List<IXMLConcreteParser> list = new List<IXMLConcreteParser>();

            list.Add(new SimpleParser());
            list.Add(new WeightParser());
            list.Add(new CardioParser());

            return list;
        }
    }
}
