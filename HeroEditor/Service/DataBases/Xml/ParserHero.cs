using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroEditor.Model;
using HeroEditor.Model.Items;
using System.IO;
using System.Xml.Linq;

namespace HeroEditor.Service.DataBases.Xml
{
    class ParserHero : IXmlParserHero
    {
        public HeroModel parseHero(string pathToHero, IEnumerable<ItemModel> items)
        {
            if (pathToHero == null) throw new ArgumentNullException("pathToHero");
            if (items == null) throw new ArgumentNullException("pathToHero");
            if (!File.Exists(pathToHero)) throw new ArgumentException("pathToHero doen't exist");

            IEnumerable<XElement> elems = GetHeroAsXElements(pathToHero);

            string id, name, chest, hat, weapon;
            id = name = chest = hat = weapon = null;

            foreach(var z in elems)
            {
                string nameOfElem = z.Name.ToString().ToLower();

                if (nameOfElem == "id")
                    id = z.Value;
                else if (nameOfElem == "chest")
                    chest = z.Value;
                else if (nameOfElem == "weapon")
                    weapon = z.Value;
                else if (nameOfElem == "hat")
                    hat = z.Value;
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

            HeroModel hero = new HeroModel();
            hero.ID = intId;
            hero.Name = name;

            if (chest != null)
            {
                foreach(var z in items)
                {
                    if (z.ID.ToString() == chest && z is ChestModel)
                        hero.Chest = z as ChestModel;
                }
            }

            if (weapon != null)
            {
                foreach (var z in items)
                {
                    if (z.ID.ToString() == weapon && z is WeaponModel)
                        hero.Weapon = z as WeaponModel;
                }
            }


            if (hat != null)
            {
                foreach (var z in items)
                {
                    if (z.ID.ToString() == hat && z is HatModel)
                        hero.Hat = z as HatModel;
                }
            }

            return hero;
        }

        private IEnumerable<XElement> GetHeroAsXElements(string pathToHero)
        {
            if (!File.Exists(pathToHero)) throw new ArgumentException("pathToHero");

            XDocument doc = new XDocument();

            try
            {
                doc = XDocument.Load(pathToHero);
            }
            catch (Exception e)
            {
                doc = null;
            }

            XElement root = doc.Element("root").Element("hero");

            if (root == null)
                return null;

            return root.Elements();
        }
    }
}
