using HeroEditor.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEditor.Service.DataBases.Xml
{
    interface IXmlParserItem
    {
        ItemModel GetItemModelFromXml(string ContentXml);
    }
}
