using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTrackerV2.Model.SportActivities.Implementations;
using TrainingTrackerV2.MagicService;
using TrainingTrackerV2.DataBase.Xml;
using System.IO;
using System.Xml;
using TrainingTrackerV2.Model.SportActivities;
using System.Threading;
using System.Windows;
using System.Reflection;


namespace TrainingTrackerV2.DataBase.Xml
{
    class ConnectionXml : IConnectionDb
    {
        private GrabberXmlExerciseFromFolder _grabber;

        public ConnectionXml(GrabberXmlExerciseFromFolder grabber)
        {
            if (grabber == null) throw new ArgumentNullException("grabber");
            _grabber = grabber;
        }


        #region Public Properties

        public IList<Model.SportActivities.ITraining> Trainings
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion


        public bool AddNewTraining(Model.SportActivities.ITraining training)
        {
            if (training == null) throw new ArgumentNullException("training");
            if (training.ID != null)
            {
                return Update(training);
            }

            if (CheckTrainingModelForErrors(training))
                return false;

            string nameForSaving = GetNameForSavingTraining(training);

            if (string.IsNullOrWhiteSpace(nameForSaving))
                throw new InvalidOperationException("nameForSaving is null or whitespace");

            if (!createNewFile(nameForSaving))
                return false;

            XmlDocument document = getXmlDocumentWithContent(nameForSaving);
            if (document == null)
                return false;

            WriteTrainingToXmlDocument(document, training);

            document.Save(nameForSaving);

            return true;
        }


        public bool RemoveTraining(Model.SportActivities.ITraining training)
        {
            string path = GetNameForSavingTraining(training);
            File.Delete(path);
            return true;
        }

        public bool UpdateTraining(Model.SportActivities.ITraining training)
        {
            throw new NotImplementedException();
        }

        public bool Update(Model.SportActivities.ITraining training)
        {
            if (training == null) throw new ArgumentNullException("training");
            if (training.ID == null) throw new ArgumentException("training.ID");

            string nameForSaving = GetNameForSavingTraining(training);

            if (string.IsNullOrWhiteSpace(nameForSaving))
                throw new InvalidOperationException("nameForSaving is null or whitespace");

            if (!createNewFile(nameForSaving))
                return false;

            XmlDocument document = getXmlDocumentWithContent(nameForSaving);
            if (document == null)
                return false;

            WriteTrainingToXmlDocument(document, training);

            document.Save(nameForSaving);

            return true;
        }

        private void WriteTrainingToXmlDocument(XmlDocument document, Model.SportActivities.ITraining trainingModel)
        {
            if (document == null) throw new ArgumentNullException("document");
            if (trainingModel == null) throw new ArgumentNullException("training");
            if (string.IsNullOrWhiteSpace(trainingModel.Name)) throw new ArgumentException("trainingModel.Name");

            XmlNode training = document.CreateElement("training");

            XmlNode nameNode = document.CreateElement("name");
            XmlText val = document.CreateTextNode(trainingModel.Name);

            nameNode.AppendChild(val);
            training.AppendChild(nameNode);

            document.DocumentElement.AppendChild(training);

            XmlNode idNode = document.CreateElement("id");
            val = document.CreateTextNode(trainingModel.ID.ToString());
            idNode.AppendChild(val);

            training.AppendChild(idNode);

            if (trainingModel.Exercises != null)
            {
                XmlNode exerciseNode = document.CreateElement("exercise");
                //  val = document.CreateTextNode(trainingModel.Exercises.ID.ToString());
                exerciseNode.AppendChild(val);
                training.AppendChild(exerciseNode);
            }
        }

        private XmlDocument getXmlDocumentWithContent(string path)
        {
            if (path == null) throw new ArgumentNullException("path");
            if (!File.Exists(path)) throw new ArgumentException("path");

            XmlDocument doc = new XmlDocument();

            for (int i = 0; i < 5; ++i)
            {
                try
                {
                    doc.Load(path);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Thread.Sleep(20);
                }
            }

            return doc;

        }

        private bool createNewFile(string path)
        {
            if (path == null) throw new ArgumentNullException("path");

            for (int i = 0; i < 5; ++i)
            {
                try
                {
                    XmlTextWriter textWritter = new XmlTextWriter(path, Encoding.UTF8);
                    textWritter.WriteStartDocument();
                    textWritter.WriteStartElement("root");
                    textWritter.WriteEndElement();

                    textWritter.Flush();
                    textWritter.Close();

                    return true;
                }
                catch
                {
                    Thread.Sleep(20);
                }
            }

            return false;
        }

        private string getPathToDb(string pathToAssembly)
        {
            if (pathToAssembly == null) throw new ArgumentNullException("pathToAssembly");

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

        private bool CheckTrainingModelForErrors(Model.SportActivities.ITraining train)
        {
            if (string.IsNullOrWhiteSpace(train.Name))
            {
                MessageBox.Show("Проблема с именем тренировки");
                return true;
            }

            return false;
        }




        private string GetNameForSavingTraining(Model.SportActivities.ITraining training)
        {
            string pathToAssembly = Assembly.GetExecutingAssembly().Location;

            string pathToFolder = getPathToDb(pathToAssembly);

            if (pathToFolder == null)
                throw new InvalidOperationException("Мы не смогли найти корень программы или проект был переименован =)");

            pathToFolder += "\\LocalXmlDb\\";

            if (!Directory.Exists(pathToFolder))
                throw new InvalidOperationException("Не смогли найти локальную базу данных в xml");


            string[] files = Directory.GetFiles(pathToFolder, "training*.xml");
            List<BaseExerciseModel> listItems = new List<BaseExerciseModel>();

            if (training.ID != null)
                return pathToFolder + "training" + training.ID.ToString() + ".xml";

            for (int i = 1; ; ++i)
            {
                bool flag = true;
                string ans = pathToFolder + "training" + i.ToString() + ".xml";

                foreach (var z in files)
                {
                    if (z == ans)
                        flag = false;
                }

                if (flag)
                {
                    training.ID = i;
                    return ans;
                }
            }

            throw new NotImplementedException("Я понятия не имею как это могло бы произойти");
        }


        public IList<IExercise> Exercises
        {
            get { throw new NotImplementedException(); }
        }
    }
}
