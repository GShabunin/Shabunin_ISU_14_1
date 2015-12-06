using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEditor.Service.DataBases.Xml
{
    class FactoryConcretParsers
    {
        public static List<IXmlConcretParser> GetParsers()
        {
            List<IXmlConcretParser> list = new List<IXmlConcretParser>();

            list.Add(new ParserWeapon());
            list.Add(new ParserChest());
            list.Add(new HatParser());

            return list;
        }
    }
}
