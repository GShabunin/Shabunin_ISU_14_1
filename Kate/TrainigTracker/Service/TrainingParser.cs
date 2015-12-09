using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainigTracker.Models;
using TrainigTracker.Models.Exercises;
using System.IO;
using System.Xml.Linq;

namespace TrainigTracker.Service
{
    class TrainingParser : IXMLParserTraining
    {
        public TrainingModel parseTraining(string pathToTraining, IEnumerable<ExerciseModel> exercises)
        {
            if (pathToTraining == null) throw new ArgumentNullException("pathToTraining");
            if (exercises == null) throw new ArgumentNullException("pathToTraining");
            if (!File.Exists(pathToTraining)) throw new ArgumentException("pathToTraining doen't exist");

            IEnumerable<XElement> elems = GetHeroAsXElements(pathToTraining);

            string id, name, cardio, weight, simple;
            id = name = cardio = weight = simple = null;

            foreach (var z in elems)
            {
                string nameOfElem = z.Name.ToString().ToLower();

                if (nameOfElem == "id")
                    id = z.Value;
                else if (nameOfElem == "cardio")
                    cardio = z.Value;
                else if (nameOfElem == "simple")
                    simple = z.Value;
                else if (nameOfElem == "weight")
                    weight = z.Value;
                else if (nameOfElem == "name")
                    name = z.Value;
            }

            if (id == null)
                return null;
            if (name == null)
                return null;

            int intId;
            if (!int.TryParse(id, out intId))
                return null;

            TrainingModel train = new TrainingModel();
            train.ID = intId;
            train.Name = name;

            if (cardio != null)
            {
                foreach (var z in exercises)
                {
                    if (z.ID.ToString() == cardio && z is CardioExerciseModel)
                        train.Cardio = z as CardioExerciseModel;
                }
            }

            if (simple != null)
            {
                foreach (var z in exercises)
                {
                    if (z.ID.ToString() == simple && z is SimpleExerciseModel)
                        train.Simple = z as SimpleExerciseModel;
                }
            }


            if (weight != null)
            {
                foreach (var z in exercises)
                {
                    if (z.ID.ToString() == weight && z is WeightExerciseModel)
                        train.Weight = z as WeightExerciseModel;
                }
            }

            return train;
        }

        private IEnumerable<XElement> GetHeroAsXElements(string pathToTraining)
        {
            if (!File.Exists(pathToTraining)) throw new ArgumentException("pathToTraining");

            XDocument doc = new XDocument();

            try
            {
                doc = XDocument.Load(pathToTraining);
            }
            catch (Exception e)
            {
                doc = null;
            }

            XElement root = doc.Element("root").Element("train");

            if (root == null)
                return null;

            return root.Elements();
        }
    }
}
