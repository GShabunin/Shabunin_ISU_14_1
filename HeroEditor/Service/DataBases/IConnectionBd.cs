using HeroEditor.Model;
using HeroEditor.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEditor.Service.DataBases
{
    interface IConnectionBd
    {
        IList<ItemModel> Items { get; }
        IList<HeroModel> Heroes { get; }
        bool Save(HeroModel hero);
        bool Remove(HeroModel hero);
        bool Update(HeroModel hero);
        bool Update(int idHero);
    }
}
