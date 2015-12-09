using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainigTracker.Models;
using System.Xml.Linq;
using System.Diagnostics;

namespace TrainigTracker.Service
{
    class GetExerciseFromXML : IXMLParserExercise
    { 
        public ExerciseModel GetItemModelFromXml(string pathToFile)
        {
            if (pathToFile == null) throw new ArgumentNullException("pathToFile");
            if (string.IsNullOrWhiteSpace(pathToFile)) throw new ArgumentException("pathToFile is empty");

            XDocument doc = new XDocument();

            try
            {
                doc = XDocument.Load(pathToFile);
            }
            catch(Exception e)
            {
                doc = null;
                Debug.Print(e.ToString());
            }

            XElement root = doc.Element("root");

            if (root == null)
                throw new InvalidOperationException("root не найден");

            List<IXMLConcreteParser> parsers = FactoryConcreteParser.GetParsers();


            foreach(var parser in parsers)
             {
                ExerciseModel result = parser.getItemFromXElement(root.Elements());

                if (result == null)
                    continue;

                return result;
            }

            return null;

        }
    }
}
