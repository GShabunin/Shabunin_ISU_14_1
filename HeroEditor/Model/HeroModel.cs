using HeroEditor.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEditor.Model
{
    class HeroModel
    {
        public string Name { get; set; }
        public int? ID { get; set; }

        public int Attack { get; set; }
        public int Defense { get; set; }
        public string Description { get; set; }

        public ChestModel Chest { get; set; }
        public HatModel Hat { get; set; }
        public WeaponModel Weapon { get; set; }
    }
}
