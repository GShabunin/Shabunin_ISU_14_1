using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TrainigTracker.Models;
using TrainigTracker.Models.Exercises;

namespace TrainigTracker.Service
{
    class SimpleParser : IXMLConcreteParser
    {
        public ExerciseModel getItemFromXElement(IEnumerable<XElement> item)
        {
            string name, id, type;


            name = "";
            type = null;
            id = null;

            foreach (var z in item)
            {
                string nameOfElem = z.Name.ToString().ToLower();
                if (nameOfElem == "name")
                    name = z.Value;
                else
                 if (nameOfElem == "id")
                    id = z.Value;
                else if (nameOfElem == "type")
                    type = z.Value;
            }

            if (string.IsNullOrEmpty(name))
                return null;

            if (string.IsNullOrEmpty(type))
                return null;

            if (type.ToLower() != "simple")
                return null;

            int intId;
            if (!int.TryParse(id, out intId))
                return null;


            SimpleExerciseModel simple = new SimpleExerciseModel();

          
            simple.ID = intId;

            return simple;
        }
    }
}
