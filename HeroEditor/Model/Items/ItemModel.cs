using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace HeroEditor.Model.Items
{
    abstract class ItemModel
    {
        protected BitmapImage _image;
        public virtual BitmapImage Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }

        protected string _type;
        public virtual string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        protected string _name;
        public virtual string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        protected string _description;
        public virtual string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        protected string _special;
        public virtual string Special
        {
            get
            {
                return _special;
            }
            set
            {
                _special = value;
            }
        }

        private string _descriptionToView;
        public virtual string DescriptionToView
        {
            get
            {
                string ans = string.Empty;

                if (!string.IsNullOrWhiteSpace(Name))
                {
                    ans += string.Format("Имя : {0}", Name);
                    ans += Environment.NewLine;
                }

                if (!string.IsNullOrWhiteSpace(_description))
                {
                    ans += string.Format("Описание : {0}", _description);
                    ans += Environment.NewLine;
                }

                if (!String.IsNullOrWhiteSpace(_special))
                {
                    ans += string.Format("Особенность : {0}", _special);
                    ans += Environment.NewLine;
                }

                return ans;
            }
        }

        public int? ID { get; set; }

        protected BitmapImage Bitmap2BitmapImage(Bitmap bitmap)
        {
            BitmapSource i = Imaging.CreateBitmapSourceFromHBitmap(
                           bitmap.GetHbitmap(),
                           IntPtr.Zero,
                           Int32Rect.Empty,
                           BitmapSizeOptions.FromEmptyOptions());


            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            MemoryStream memoryStream = new MemoryStream();
            BitmapImage bImg = new BitmapImage();

            encoder.Frames.Add(BitmapFrame.Create(i));
            encoder.Save(memoryStream);

            bImg.BeginInit();
            bImg.StreamSource = new MemoryStream(memoryStream.ToArray());
            bImg.EndInit();

            memoryStream.Close();

            return bImg;
        }

    }
}
