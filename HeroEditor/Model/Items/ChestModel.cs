using HeroEditor.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace HeroEditor.Model.Items
{
    class ChestModel : ItemModel
    {
        #region Public Properties

        public override BitmapImage Image
        {
            get
            {
                if (_image == null)
                {
                    _image = Bitmap2BitmapImage(Resources.armour);
                }
                return _image;
            }

            set
            {
                _image = value;
            }
        }

        private int? _defense;
        public int Defense
        {
            get
            {
                if (!_defense.HasValue)
                    throw new InvalidOperationException("_defense == null");

                return _defense.Value;
            }
            set { _defense = value; }
        }

        public override string DescriptionToView
        {
            get
            {
                string ans = base.DescriptionToView;

                if (_defense.HasValue)
                {
                    ans += string.Format("Защита : {0}", _defense.Value);
                    ans += Environment.NewLine;
                }

                return ans;
            }
        }

        #endregion

    }
}
