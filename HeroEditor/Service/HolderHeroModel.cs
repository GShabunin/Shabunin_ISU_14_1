using HeroEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEditor.Service
{
    class HolderHeroModel
    {
        protected static HeroModel _heroModel;

        public static HeroModel Hero
        {
            get
            {
                if (_heroModel == null)
                    _heroModel = new HeroModel();

                return _heroModel;
            }
            set
            {
                _heroModel = value;
            }
        }

        public static void CleanHeroModel()
        {
            Hero = null;
        }

    }
}
