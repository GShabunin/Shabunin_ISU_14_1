using HeroEditor.Model;
using HeroEditor.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEditor.Service.DataBases.Xml
{
    interface IXmlParserHero
    {
        HeroModel parseHero(string pathToHero, IEnumerable<ItemModel> items);
    }
}
