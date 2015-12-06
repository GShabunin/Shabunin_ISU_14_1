using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HeroEditor.Model.Items;

namespace HeroEditor.Service.DataBases.Xml
{
    class ParserChest : IXmlConcretParser
    {
        public ItemModel getItemFromXElement(IEnumerable<XElement> item)
        {
            string name, defense, special, id, description, type;

            // У НАС ТУТ ВИДИТЕ ЛИ ЛИ ОЧЕНЬ УМНАЯ ВИЖЛА
            // ТАК ЧТО ЭТА ХЕРНЯ НУЖНА ДЛЯ ТОГО
            // ЧТОБЫ ЭТА ТВАРЬ ЗАКРЫЛА СВОЙ РОТ!

            defense = "";
            name = defense;
            special = name;
            description = special;
            type = null;
            id = null;

            foreach (var z in item)
            {
                string nameOfElem = z.Name.ToString().ToLower();

                if (nameOfElem == "name")
                    name = z.Value;
                else if (nameOfElem == "defense")
                    defense = z.Value;
                else if (nameOfElem == "special")
                    special = z.Value;
                else if (nameOfElem == "id")
                    id = z.Value;
                else if (nameOfElem == "description")
                    description = z.Value;
                else if (nameOfElem == "type")
                    type = z.Value;
            }

            if (string.IsNullOrEmpty(name))
                return null;

            if (string.IsNullOrEmpty(type))
                return null;

            if (type.ToLower() != "chest")
                return null;

            int intDefense;
            if (!int.TryParse(defense, out intDefense))
                return null;

            int intId;
            if (!int.TryParse(id, out intId))
                return null;


            ChestModel chest = new ChestModel();

            chest.Defense = intDefense;
            chest.Name = name;
            chest.Special = special;
            chest.Description = description;
            chest.ID = intId;

            return chest;
        }
    }
}
