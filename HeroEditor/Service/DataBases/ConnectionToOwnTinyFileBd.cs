using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroEditor.Model;
using HeroEditor.Model.Items;
using System.Windows;
using HeroEditor.Service.DataBases.Xml;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Threading;

namespace HeroEditor.Service.DataBases
{
    class ConnectionToOwnTinyFileBd : IConnectionBd
    {
        private GrabberXmlItemsFromFolder _grabber;

        public ConnectionToOwnTinyFileBd(GrabberXmlItemsFromFolder grabber)
        {
            if (grabber == null) throw new ArgumentNullException("grabber");
            _grabber = grabber;
        }

        #region Public Properties

        private List<ItemModel> _list;
        public IList<ItemModel> Items
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<ItemModel>();
                    _list = _grabber.getItems();
                }

                return _list;
            }
        }

        private List<HeroModel> _heroes;
        public IList<HeroModel> Heroes
        {
            get
            {
                if (_heroes == null)
                {
                    _heroes = new List<HeroModel>();

                    foreach (var z in _grabber.getHeroes())
                        _heroes.Add(z);
                }

                return _heroes;
            }
        }

        #endregion

        public bool Remove(HeroModel hero)
        {
            string path = GetNameForSavingHero(hero);
            File.Delete(path);

            return true;
        }

        public bool Save(HeroModel hero)
        {
            if (hero == null) throw new ArgumentNullException("hero");
            if (hero.ID != null)
            {
                return Update(hero);
            }

            if (CheckHeroModelForErrors(hero))
                return false;

            string nameForSaving = GetNameForSavingHero(hero);

            if (string.IsNullOrWhiteSpace(nameForSaving))
                throw new InvalidOperationException("nameForSaving is null or whitespace");

            if (!createNewFile(nameForSaving))
                return false;

            XmlDocument document = getXmlDocumentWithContent(nameForSaving);
            if (document == null)
                return false;

            WriteHeroToXmlDocument(document, hero);

            document.Save(nameForSaving);

            return true;
        }

        public bool Update(int idHero)
        {
            throw new NotImplementedException();
        }

        public bool Update(HeroModel hero)
        {
            if (hero == null) throw new ArgumentNullException("hero");
            if (hero.ID == null) throw new ArgumentException("hero.ID");

            string nameForSaving = GetNameForSavingHero(hero);

            if (string.IsNullOrWhiteSpace(nameForSaving))
                throw new InvalidOperationException("nameForSaving is null or whitespace");

            if (!createNewFile(nameForSaving))
                return false;

            XmlDocument document = getXmlDocumentWithContent(nameForSaving);
            if (document == null)
                return false;

            WriteHeroToXmlDocument(document, hero);

            document.Save(nameForSaving);

            return true;
        }

        private void WriteHeroToXmlDocument(XmlDocument document, HeroModel heroModel)
        {
            if (document == null) throw new ArgumentNullException("document");
            if (heroModel == null) throw new ArgumentNullException("hero");
            if (string.IsNullOrWhiteSpace(heroModel.Name)) throw new ArgumentException("heroModel.Name");

            XmlNode hero = document.CreateElement("hero");

            XmlNode nameNode = document.CreateElement("name");
            XmlText val = document.CreateTextNode(heroModel.Name);

            nameNode.AppendChild(val);
            hero.AppendChild(nameNode);

            document.DocumentElement.AppendChild(hero);

            XmlNode idNode = document.CreateElement("id");
            val = document.CreateTextNode(heroModel.ID.ToString());
            idNode.AppendChild(val);

            hero.AppendChild(idNode);

            if (heroModel.Hat != null)
            {
                XmlNode hatNode = document.CreateElement("hat");
                val = document.CreateTextNode(heroModel.Hat.ID.ToString());
                hatNode.AppendChild(val);
                hero.AppendChild(hatNode);
            }
            if (heroModel.Chest != null)
            {
                XmlNode chestNode = document.CreateElement("chest");
                val = document.CreateTextNode(heroModel.Chest.ID.ToString());
                chestNode.AppendChild(val);
                hero.AppendChild(chestNode);
            }
            if (heroModel.Weapon != null)
            { 
                XmlNode weaponNode = document.CreateElement("weapon");
                val = document.CreateTextNode(heroModel.Weapon.ID.ToString());
                weaponNode.AppendChild(val);
                hero.AppendChild(weaponNode);
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
        private string GetNameForSavingHero(HeroModel hero)
        {
            string pathToAssembly = Assembly.GetExecutingAssembly().Location;

            string pathToFolder = getPathToDb(pathToAssembly);

            if (pathToFolder == null)
                throw new InvalidOperationException("Мы не смогли найти корень программы или проект был переименован =)");

            pathToFolder += "\\LocalXmlDb\\";

            if (!Directory.Exists(pathToFolder))
                throw new InvalidOperationException("Не смогли найти локальную базу данных в xml");


            string[] files = Directory.GetFiles(pathToFolder, "hero*.xml");
            List<ItemModel> listItems = new List<ItemModel>();

            if (hero.ID != null)
                return pathToFolder + "hero" + hero.ID.ToString() + ".xml";

            for (int i = 1; ; ++i)
            {
                bool flag = true;
                string ans = pathToFolder + "hero" + i.ToString() + ".xml";

                foreach (var z in files)
                {
                    if (z == ans)
                        flag = false;
                }

                if (flag)
                {
                    hero.ID = i;
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

        private bool CheckHeroModelForErrors(HeroModel hero)
        {
            if (string.IsNullOrWhiteSpace(hero.Name))
            {
                MessageBox.Show("Проблемка вышла у нас с именем хероя");
                return true;
            }

            return false;
        }
    }
}
