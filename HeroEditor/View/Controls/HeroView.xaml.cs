using HeroEditor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HeroEditor.View.Controls
{
    /// <summary>
    /// Interaction logic for HeroView.xaml
    /// </summary>
    public partial class HeroView : UserControl
    {
        public HeroView()
        {
            InitializeComponent();
        }

        private void TextBlock_Drop(object sender, DragEventArgs e)
        {
            ItemViewModel vm = e.Data.GetData(typeof(ItemViewModel)) as ItemViewModel;
            if (vm == null)
                MessageBox.Show(e.Data.GetData(typeof(ItemViewModel)).GetType().ToString());
            else
                MessageBox.Show(vm.DescriptionToView);
        }
    }
}
