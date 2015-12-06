using GalaSoft.MvvmLight;
using HeroEditor.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HeroEditor.ViewModel
{
    class ItemViewModel : ViewModelBase
    {
        protected ItemModel _model;
        public BitmapImage Image
        {
            get
            {
                return _model.Image;
            }
        }

        public ItemModel Model
        {
            get
            {
                return _model;
            }
        }

        public ItemViewModel(ItemModel model)
        {
            if (model == null) throw new ArgumentNullException("model");
            _model = model;
        }

        public string DescriptionToView
        {
            get
            {
                return _model.DescriptionToView;
            }
        }
    }
}
