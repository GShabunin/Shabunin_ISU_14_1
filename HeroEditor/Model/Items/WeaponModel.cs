using HeroEditor.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HeroEditor.Model.Items
{
    class WeaponModel : ItemModel
    {
        public override BitmapImage Image
        {
            get
            {
                if (_image == null)
                {
                    _image = Bitmap2BitmapImage(Resources.sword);
                }
                return _image;
            }

            set
            {
                _image = value;
            }
        }

        private int? _attack;
        public int Attack
        {
            get
            {
                if (!_attack.HasValue) throw new InvalidOperationException("_attack is null");
                return _attack.Value;
            }
            set { _attack = value; }
        }

        public override string DescriptionToView
        {
            get
            {
                string ans = base.DescriptionToView;

                ans += string.Format("Атака : {0}", Attack);
                ans += Environment.NewLine;

                return ans;
            }
        }

    }
}
