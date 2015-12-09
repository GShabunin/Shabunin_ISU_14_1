using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainigTracker.Models;
using TrainigTracker.Models.Exercises;
using System.Windows;
using TrainigTracker.Service;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Threading;



namespace TrainigTracker.Service
{
    class ConnectionToBD: IConnectionBd
    {
        private XMLTrGrabber _grabber;

        public ConnectionToBD(XMLTrGrabber grabber)
        {
            if (grabber == null) throw new ArgumentNullException("grabber");
            _grabber = grabber;
        }

        #region Public Properties

        private List<ExerciseModel> _list;
        public IList<ExerciseModel> Exercises
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<ExerciseModel>();
                    _list = _grabber.getExercises();
                }

                return _list;
            }
        }

        private List<TrainingModel> _trains;
        public IList<TrainingModel> Trains
        {
            get
            {
                if (_trains == null)
                {
                    _trains = new List<TrainingModel>();

                    foreach (var z in _grabber.getTrains())
                        _trains.Add(z);
                }

                return _trains;
            }
        }

        #endregion

        public bool Remove(TrainingModel train)
        {
            //смотри - определение этого метода идет ниже в этом файле!
          
            string path = GetNameForSavingHero(train);
            File.Delete(path);

            return true;
        }

        public bool Save(TrainingModel train)
        {
            if (train == null) throw new ArgumentNullException("train");
            if (train.ID != null)
            {
             return Update(train);
            }

            if (CheckHeroModelForErrors(train))
                return false;

            string nameForSaving = GetNameForSavingHero(train);

            if (string.IsNullOrWhiteSpace(nameForSaving))
                throw new InvalidOperationException("nameForSaving is null or whitespace");

            if (!createNewFile(nameForSaving))
                return false;

            XmlDocument document = getXmlDocumentWithContent(nameForSaving);
            if (document == null)
                return false;

            WriteHeroToXmlDocument(document, train);

            document.Save(nameForSaving);

            return true;
        }

        public bool Update(int idHero)
        {
            throw new NotImplementedException();
        }

        public bool Update(TrainingModel train)
        {
            if (train == null) throw new ArgumentNullException("train");
            if (train.ID == null) throw new ArgumentException("train.ID");

            string nameForSaving = GetNameForSavingHero(train);

            if (string.IsNullOrWhiteSpace(nameForSaving))
                throw new InvalidOperationException("nameForSaving is null or whitespace");

            if (!createNewFile(nameForSaving))
                return false;

            XmlDocument document = getXmlDocumentWithContent(nameForSaving);
            if (document == null)
                return false;

            WriteHeroToXmlDocument(document, train);

            document.Save(nameForSaving);

            return true;
        }

        private void WriteHeroToXmlDocument(XmlDocument document, TrainingModel trainModel)
        {
            if (document == null) throw new ArgumentNullException("document");
            if (trainModel == null) throw new ArgumentNullException("train");
            if (string.IsNullOrWhiteSpace(trainModel.Name)) throw new ArgumentException("trainModel.Name");

            XmlNode train = document.CreateElement("train");

            XmlNode nameNode = document.CreateElement("name");
            XmlText val = document.CreateTextNode(trainModel.Name);

            nameNode.AppendChild(val);
            train.AppendChild(nameNode);

            document.DocumentElement.AppendChild(train);

            XmlNode idNode = document.CreateElement("id");
            val = document.CreateTextNode(trainModel.ID.ToString());
            idNode.AppendChild(val);

            train.AppendChild(idNode);

            if (trainModel.Cardio != null)
            {
                XmlNode cardioNode = document.CreateElement("cardio");
                val = document.CreateTextNode(trainModel.Cardio.ID.ToString());
                cardioNode.AppendChild(val);
                train.AppendChild(cardioNode);
            }
            if (trainModel.Weight != null)
            {
                XmlNode weightNode = document.CreateElement("weight");
                val = document.CreateTextNode(trainModel.Weight.ID.ToString());
                weightNode.AppendChild(val);
                train.AppendChild(weightNode);
            }
            if (trainModel.Simple != null)
            { 
                XmlNode simpleNode = document.CreateElement("simple");
                val = document.CreateTextNode(trainModel.Simple.ID.ToString());
                simpleNode.AppendChild(val);
                train.AppendChild(simpleNode);
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

        /// <summary>
        /// Важно. Помимо имени файла он еще присваивает к HeroModel значение его ID, если оно было null
        /// </summary>
        private string GetNameForSavingHero(TrainingModel train)
        {
            string pathToAssembly = Assembly.GetExecutingAssembly().Location;

            string pathToFolder = getPathToDb(pathToAssembly);

            if (pathToFolder == null)
                throw new InvalidOperationException("Мы не смогли найти корень программы или проект был переименован =)");

            pathToFolder += "\\LocalDb\\";

            if (!Directory.Exists(pathToFolder))
                throw new InvalidOperationException("Не смогли найти локальную базу данных в xml");


            string[] files = Directory.GetFiles(pathToFolder, "train*.xml");
            List<ExerciseModel> listItems = new List<ExerciseModel>();

            if (train.ID != null)
                return pathToFolder + "train" + train.ID.ToString() + ".xml";

            for (int i = 1; ; ++i)
            {
                bool flag = true;
                string ans = pathToFolder + "train" + i.ToString() + ".xml";

                foreach (var z in files)
                {
                    if (z == ans)
                        flag = false;
                }

                if (flag)
                {
                    train.ID = i;
                    return ans;
                }
            }

            throw new NotImplementedException("Я понятия не имею как это могло бы произойти");   
        }

        private string getPathToDb(string pathToAssembly)
        {
            if (pathToAssembly == null) throw new ArgumentNullException("pathToAssembly");

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

        private bool CheckHeroModelForErrors(TrainingModel train)
        {
            if (string.IsNullOrWhiteSpace(train.Name))
            {
                MessageBox.Show("Проблемка вышла у нас с именем тренировки");
                return true;
            }

            return false;
        }
    }
}
