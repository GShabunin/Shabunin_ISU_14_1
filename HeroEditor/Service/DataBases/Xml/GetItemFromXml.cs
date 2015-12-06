using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroEditor.Model.Items;
using System.Xml.Linq;
using System.Diagnostics;

namespace HeroEditor.Service.DataBases.Xml
{
    class GetItemFromXml : IXmlParserItem
    {
        public ItemModel GetItemModelFromXml(string pathToFile)
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

            List<IXmlConcretParser> parsers = FactoryConcretParsers.GetParsers();


            foreach(var parser in parsers)
             {
                ItemModel result = parser.getItemFromXElement(root.Elements());

                if (result == null)
                    continue;

                return result;
            }

            return null;

        }
    }
}
