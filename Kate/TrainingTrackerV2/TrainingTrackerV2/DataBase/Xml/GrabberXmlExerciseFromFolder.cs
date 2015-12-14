using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using TrainingTrackerV2.Model;
using TrainingTrackerV2.Model.SportActivities;
using TrainingTrackerV2.Model.SportActivities.Implementations;

namespace TrainingTrackerV2.DataBase.Xml
{
    class GrabberXmlExerciseFromFolder
    {
        private IXmlParserExercise _parser;
        private IXmlParserTraining _parserTraining;

        public GrabberXmlExerciseFromFolder(IXmlParserExercise parser, IXmlParserTraining parserTraining)
        {
            if (parser == null) throw new ArgumentNullException("parser");
            if (parserTraining == null) throw new ArgumentNullException("parserTraining");

            _parser = parser;
            _parserTraining = parserTraining;
        }

        public List<TrainingModel> getTraining()
        {
            string pathToAssembly = Assembly.GetExecutingAssembly().Location;

            string pathToFolder = getPathToDb(pathToAssembly);

            if (pathToFolder == null)
                throw new InvalidOperationException("Мы не смогли найти корень программы или проект был переименован =)");

            pathToFolder += "\\LocalXmlDb\\";

            if (!Directory.Exists(pathToFolder))
                throw new InvalidOperationException("Не смогли найти локальную базу данных в xml");


            string[] files = Directory.GetFiles(pathToFolder, "training*.xml");

            List<TrainingModel> trainings = new List<TrainingModel>();
            List<BaseExerciseModel> items = getItems();

            foreach(var z in files)
            {
                TrainingModel newTraining = _parserTraining.parseTraining(z, items);

                if (newTraining != null) trainings.Add(newTraining);
            }

            return trainings;
        }

        public List<BaseExerciseModel> getItems()
        {
            string pathToAssembly = Assembly.GetExecutingAssembly().Location;

            string pathToFolder = getPathToDb(pathToAssembly);

            if (pathToFolder == null)
                throw new InvalidOperationException("Мы не смогли найти корень программы или проект был переименован =)");

            pathToFolder += "\\LocalXmlDb\\";

            if (!Directory.Exists(pathToFolder))
                throw new InvalidOperationException("Не смогли найти локальную базу данных в xml");


            string[] files = Directory.GetFiles(pathToFolder, "*.xml");
            List<BaseExerciseModel> listItems = new List<BaseExerciseModel>();

            foreach(var z in files)
            {
                parseXml(listItems, z);
            }

            return listItems;
        }

        private void parseXml(IList<BaseExerciseModel> listItems, string pathToFile)
        {
            BaseExerciseModel result = _parser.GetExerciseModelFromXml(pathToFile);

            if (result != null)
                listItems.Add(result);
        }

        private string getPathToDb(string pathToAssembly)
        {
            string look = string.Empty;

           
            for (int i = 0; i < 10; ++i)
            {
                look = Path.GetDirectoryName(pathToAssembly);
                look = look.Split('\\').Last<string>();


                if (look == "TrainingTrackerV2")
                {
                    pathToAssembly = Directory.GetParent(pathToAssembly).ToString();
                    break;
                }
                else
                {
                    pathToAssembly = Directory.GetParent(pathToAssembly).ToString();
                }
            }


            if (look != "TrainingTrackerV2")
            {
                return null;
            }

            return pathToAssembly;
        }

        public List<BaseExerciseModel> getItems(string pathToFolder)
        {
            if (pathToFolder == null) throw new ArgumentNullException("pathToFolder");
            if (string.IsNullOrWhiteSpace(pathToFolder)) throw new ArgumentException("pathToFolder is empty");

            throw new NotImplementedException();
        }
    }
}
