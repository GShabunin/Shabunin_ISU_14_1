using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HeroEditor.Model.Items;

namespace HeroEditor.Service.DataBases.Xml
{
    class ParserWeapon : IXmlConcretParser
    {
        public ItemModel getItemFromXElement(IEnumerable<XElement> item)
        {
            string name, attack, special, id, description, type;

            // У НАС ТУТ ВИДИТЕ ЛИ ЛИ ОЧЕНЬ УМНАЯ ВИЖЛА
            // ТАК ЧТО ЭТА ХЕРНЯ НУЖНА ДЛЯ ТОГО
            // ЧТОБЫ ЭТА ТВАРЬ ЗАКРЫЛА СВОЙ РОТ!

            attack = "";
            name = attack;
            special = name;
            description = special;
            type = null;
            id = null;

            foreach(var z in item)
            {
                string nameOfElem = z.Name.ToString().ToLower();

                if (nameOfElem == "name")
                    name = z.Value;
                else if (nameOfElem == "attack")
                    attack = z.Value;
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

            if (type.ToLower() != "weapon")
                return null;

            int intAttack;
            if (!int.TryParse(attack, out intAttack))
                return null;

            int intId;
            if (!int.TryParse(id, out intId))
                return null;

            WeaponModel weapon = new WeaponModel();

            weapon.Attack = intAttack;
            weapon.Name = name;
            weapon.Special = special;
            weapon.Description = description;
            weapon.ID = intId;

            return weapon;
        }
    }
}
