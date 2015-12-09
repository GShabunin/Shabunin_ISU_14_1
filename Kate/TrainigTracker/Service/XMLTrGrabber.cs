//здесь ошибки смотри код
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using TrainigTracker.Models;
using TrainigTracker.Models.Exercises;

namespace TrainigTracker.Service
{
    class XMLTrGrabber
    {
        private IXMLParserExercise _parser;
        private IXMLParserTraining _parserTraining;

        public XMLTrGrabber(IXMLParserExercise parser, IXMLParserTraining parserTraining)
        {
            //ты остановился здесь
            if (parser == null) throw new ArgumentNullException("parser");
            if (parserTraining == null) throw new ArgumentNullException("parserTraining");

            _parser = parser;
            _parserTraining = parserTraining;
        }

        public List<TrainingModel> getTrains()
        {
            string pathToAssembly = Assembly.GetExecutingAssembly().Location;

            string pathToFolder = getPathToDb(pathToAssembly);

            if (pathToFolder == null)
                throw new InvalidOperationException("Мы не смогли найти корень программы или проект был переименован =)");

            pathToFolder += "\\LocalDb\\";

            if (!Directory.Exists(pathToFolder))
                throw new InvalidOperationException("Не смогли найти локальную базу данных в xml");


            string[] files = Directory.GetFiles(pathToFolder, "training*.xml");

            List<TrainingModel> trains = new List<TrainingModel>();
            List<ExerciseModel> exercises = getExercises();

            foreach(var z in files)
            {
                TrainingModel newTrain = _parserTraining.parseTraining(z, exercises);

                if (newTrain != null) trains.Add(newTrain);
            }

            return trains;
        }

        public List<ExerciseModel> getExercises()
        {
            string pathToAssembly = Assembly.GetExecutingAssembly().Location;

            string pathToFolder = getPathToDb(pathToAssembly);

            if (pathToFolder == null)
                throw new InvalidOperationException("Мы не смогли найти корень программы или проект был переименован =)");

            pathToFolder += "\\LocalDb\\";

            if (!Directory.Exists(pathToFolder))
                throw new InvalidOperationException("Не смогли найти локальную базу данных в xml");


            string[] files = Directory.GetFiles(pathToFolder, "*.xml");
            List<ExerciseModel> listExercises = new List<ExerciseModel>();

            foreach(var z in files)
            {
                parseXml(listExercises, z);
            }

            return listExercises;
        }

        private void parseXml(IList<ExerciseModel> listExercises, string pathToFile)
        {
            ExerciseModel result = _parser.GetItemModelFromXml(pathToFile);

            if (result != null)
                listExercises.Add(result);
        }

        private string getPathToDb(string pathToAssembly)
        {
            string look = string.Empty;

            // Да, сие есть царство говнокода , но иначе не получается покамест
            // Дальше посмотрим как получится =) Постараюсь переписать годно.
            for (int i = 0; i < 10; ++i)
            {
                look = Path.GetDirectoryName(pathToAssembly);
                look = look.Split('\\').Last<string>();


                if (look == "TrainigTracker")
                {
                    pathToAssembly = Directory.GetParent(pathToAssembly).ToString();
                    break;
                }
                else
                {
                    pathToAssembly = Directory.GetParent(pathToAssembly).ToString();
                }
            }


            if (look != "TrainigTracker")
            {
                return null;
            }

            return pathToAssembly;
        }

        public List<ExerciseModel> getItems(string pathToFolder)
        {
            if (pathToFolder == null) throw new ArgumentNullException("pathToFolder");
            if (string.IsNullOrWhiteSpace(pathToFolder)) throw new ArgumentException("pathToFolder is empty");

            throw new NotImplementedException();
        }
    }
 
}
