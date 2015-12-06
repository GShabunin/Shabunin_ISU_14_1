using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HeroEditor.Model.Factories;
using HeroEditor.Model.Items;
using HeroEditor.Service.DataBases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HeroEditor.ViewModel
{
    class ChoiceItemsControlViewModel : ViewModelBase
    {
        private IConnectionBd _connection;

        public ChoiceItemsControlViewModel(IConnectionBd connection)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            _connection = connection;
        }

        #region Commands

        private RelayCommand<MouseButtonEventArgs> _listBoxMouseDown;
        public RelayCommand<MouseButtonEventArgs> ListBoxMouseDown
        {
            get
            {
                if (_listBoxMouseDown == null)
                    _listBoxMouseDown = new RelayCommand<MouseButtonEventArgs>(executeListBoxMouseDown);

                return _listBoxMouseDown;
            }
        }

        private void executeListBoxMouseDown(MouseButtonEventArgs e)
        {
            //MessageBox.Show(e.Source.GetType().ToString());

            ListView list = e.Source as ListView;

            if (list == null)
                return;

            if (list.SelectedItem == null)
                return;

            ItemViewModel vm = list.SelectedItem as ItemViewModel;

            if (vm == null)
                return;

            DragDrop.DoDragDrop(list, vm, DragDropEffects.Copy);
        }

        #endregion

        #region Public Properties

        private ObservableCollection<ItemViewModel> _chests;
        public ObservableCollection<ItemViewModel> Chests
        {
            get
            {
                if (_chests == null)
                {
                    _chests = new ObservableCollection<ItemViewModel>();
                    ChestFactory chestFactory = new ChestFactory(_connection);

                    // Костыль для того, чтобы посмотреть как будет выглядеть лист с большим количеством элементов
                    foreach (var z in chestFactory.Items)
                    {
                        _chests.Add(new ItemViewModel(z));
                    }
                }
                return _chests;
            }
        }


        private ObservableCollection<ItemViewModel> _hats;
        public ObservableCollection<ItemViewModel> Hats
        {
            get
            {
                if (_hats == null)
                {
                    _hats = new ObservableCollection<ItemViewModel>();

                    HatFactory hatFactory = new HatFactory(_connection);
                    foreach (var z in hatFactory.Items)
                        _hats.Add(new ItemViewModel(z));

                }
                return _hats;
            }
        }

        private ObservableCollection<ItemViewModel> _weapons;
        public ObservableCollection<ItemViewModel> Weapons
        {
            get
            {
                if (_weapons == null)
                {
                    _weapons = new ObservableCollection<ItemViewModel>();

                    WeaponFactory weaponFactory = new WeaponFactory(_connection);
                    foreach (var z in weaponFactory.Items)
                        _weapons.Add(new ItemViewModel(z));

                }
                return _weapons;
            }
        }

        #endregion


    }
}
