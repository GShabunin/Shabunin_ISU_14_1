using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _8Puzzle
{
    /// <summary>
    /// Interaction logic for ItemCntr.xaml
    /// </summary>
    public partial class ItemCntr : UserControl   
    {
        public int IntVal
        {
            get { return mIntVal; }
            set 
            {
                tbVal.Text = (value == 0) ? "" : value.ToString();
                mIntVal = value;
            }
        }   private int mIntVal;

        public int I { get; set; }
        public int J { get; set; }
        

        public static readonly DependencyProperty DisplayValProperty =
             DependencyProperty.Register("DisplayVal", typeof(string), typeof(ItemCntr), new UIPropertyMetadata(null));

        public string DisplayVal
        {
            get { return (string)GetValue(DisplayValProperty); }
        }

        public ItemCntr()
        {
            InitializeComponent();
        }

    }
}
