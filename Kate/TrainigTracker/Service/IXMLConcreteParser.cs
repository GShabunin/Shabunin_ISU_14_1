using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TrainigTracker.Models;
namespace TrainigTracker.Service
{
    interface IXMLConcreteParser
    {
        ExerciseModel getItemFromXElement(IEnumerable<XElement> exercise);
    }
}
