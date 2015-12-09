using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainigTracker.Models;
using System.Xml.Linq;
using TrainigTracker.Models.Exercises;

namespace TrainigTracker.Service
{
    class CardioParser:IXMLConcreteParser
    {
        public ExerciseModel getItemFromXElement(IEnumerable<XElement> item)
        {
            string  name, id, type;

            //посмотри здесь ошибка!
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

            if (type.ToLower() != "cardio")
                return null;

            int intId;
            if (!int.TryParse(id, out intId))
                return null;


            CardioExerciseModel cardio = new CardioExerciseModel();

            cardio.ID = intId;

            return cardio;
        }
    }
}

