using HeroEditor.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HeroEditor.Service.DataBases.Xml
{
    interface IXmlConcretParser
    {
        ItemModel getItemFromXElement(IEnumerable< XElement > item);
    }
}
