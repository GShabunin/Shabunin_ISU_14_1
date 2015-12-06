using HeroEditor.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using HeroEditor.Model;

namespace HeroEditor.Service.DataBases.Xml
{
    class GrabberXmlItemsFromFolder
    {
        private IXmlParserItem _parser;
        private IXmlParserHero _parserHero;

        public GrabberXmlItemsFromFolder(IXmlParserItem parser, IXmlParserHero parserHero)
        {
            if (parser == null) throw new ArgumentNullException("parser");
            if (parserHero == null) throw new ArgumentNullException("parserHero");

            _parser = parser;
            _parserHero = parserHero;
        }

        public List<HeroModel> getHeroes()
        {
            string pathToAssembly = Assembly.GetExecutingAssembly().Location;

            string pathToFolder = getPathToDb(pathToAssembly);

            if (pathToFolder == null)
                throw new InvalidOperationException("Мы не смогли найти корень программы или проект был переименован =)");

            pathToFolder += "\\LocalXmlDb\\";

            if (!Directory.Exists(pathToFolder))
                throw new InvalidOperationException("Не смогли найти локальную базу данных в xml");


            string[] files = Directory.GetFiles(pathToFolder, "hero*.xml");

            List<HeroModel> heroes = new List<HeroModel>();
            List<ItemModel> items = getItems();

            foreach(var z in files)
            {
                HeroModel newHero = _parserHero.parseHero(z, items);

                if (newHero != null) heroes.Add(newHero);
            }

            return heroes;
        }

        public List<ItemModel> getItems()
        {
            string pathToAssembly = Assembly.GetExecutingAssembly().Location;

            string pathToFolder = getPathToDb(pathToAssembly);

            if (pathToFolder == null)
                throw new InvalidOperationException("Мы не смогли найти корень программы или проект был переименован =)");

            pathToFolder += "\\LocalXmlDb\\";

            if (!Directory.Exists(pathToFolder))
                throw new InvalidOperationException("Не смогли найти локальную базу данных в xml");


            string[] files = Directory.GetFiles(pathToFolder, "*.xml");
            List<ItemModel> listItems = new List<ItemModel>();

            foreach(var z in files)
            {
                parseXml(listItems, z);
            }

            return listItems;
        }

        private void parseXml(IList<ItemModel> listItems, string pathToFile)
        {
            ItemModel result = _parser.GetItemModelFromXml(pathToFile);

            if (result != null)
                listItems.Add(result);
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


                if (look == "HeroEditor")
                {
                    pathToAssembly = Directory.GetParent(pathToAssembly).ToString();
                    break;
                }
                else
                {
                    pathToAssembly = Directory.GetParent(pathToAssembly).ToString();
                }
            }


            if (look != "HeroEditor")
            {
                return null;
            }

            return pathToAssembly;
        }

        public List<ItemModel> getItems(string pathToFolder)
        {
            if (pathToFolder == null) throw new ArgumentNullException("pathToFolder");
            if (string.IsNullOrWhiteSpace(pathToFolder)) throw new ArgumentException("pathToFolder is empty");

            throw new NotImplementedException();
        }
    }
}
