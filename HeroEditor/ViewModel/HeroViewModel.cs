using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HeroEditor.Model;
using HeroEditor.Model.Items;
using HeroEditor.Service.DataBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace HeroEditor.ViewModel
{
    class HeroViewModel : ViewModelBase
    {
        #region Private Fields

        private HeroModel _heroModel;
        private IConnectionBd _connection;

        #endregion

        #region Public Properties

        public BitmapImage HatImage
        {
            get
            {
                if (_heroModel.Hat != null)
                    return _heroModel.Hat.Image;

                return null;
            }
        }

        public BitmapImage ChestImage
        {
            get
            {
                if (_heroModel.Chest != null)
                    return _heroModel.Chest.Image;

                return null;
            }
        }

        public BitmapImage WeaponImage
        {
            get
            {
                if (_heroModel.Weapon != null)
                    return _heroModel.Weapon.Image;

                return null;
            }
        }

        public int Attack
        {
            get
            {
                int result = 0;

                if (_heroModel.Weapon != null)
                    result += _heroModel.Weapon.Attack;

                return result;
            }
        }

        public int Defense
        {
            get
            {
                int result = 0;

                if (_heroModel.Chest != null)
                    result += _heroModel.Chest.Defense;
                if (_heroModel.Hat != null)
                    result += _heroModel.Hat.Defense;

                return result;
            }
        }


        public string Name
        {
            get
            {
                return _heroModel.Name;
            }
            set
            {
                _heroModel.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        #endregion

        #region Commands

        private RelayCommand _buttonSave;
        public RelayCommand ButtonSave
        {
            get
            {
                if (_buttonSave == null)
                {
                    _buttonSave = new RelayCommand(buttonSaveExecute);
                }
                return _buttonSave;
            }
        }

        private void buttonSaveExecute()
        {
            _connection.Save(_heroModel);
        }


        private RelayCommand<MouseButtonEventArgs> _weaponMouseDown;
        public RelayCommand<MouseButtonEventArgs> WeaponMouseDown
        {
            get
            {
                if (_weaponMouseDown == null)
                    _weaponMouseDown = new RelayCommand<MouseButtonEventArgs>(_weaponMouseDownExecute);
                return _weaponMouseDown;
            }
        }

        private void _weaponMouseDownExecute(MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                _heroModel.Weapon = null;
                RaisePropertyChanged("Attack");
                RaisePropertyChanged("WeaponImage");
            }
        }

        private RelayCommand<DragEventArgs> _weaponDrop;
        public RelayCommand<DragEventArgs> WeaponDrop
        {
            get
            {
                if (_weaponDrop == null)
                    _weaponDrop = new RelayCommand<DragEventArgs>(weaponDropExecute);

                return _weaponDrop;
            }
        }

        private void weaponDropExecute(DragEventArgs e)
        {
            ItemViewModel vm = e.Data.GetData(typeof(ItemViewModel)) as ItemViewModel;

            if (vm == null) return;

            WeaponModel model = vm.Model as WeaponModel;

            if (model == null) return;

            _heroModel.Weapon = model;

            RaisePropertyChanged("Attack");
            RaisePropertyChanged("WeaponImage");
        }


        private RelayCommand<MouseButtonEventArgs> _chestMouseDown;
        public RelayCommand<MouseButtonEventArgs> ChestMouseDown
        {
            get
            {
                if (_chestMouseDown == null)
                    _chestMouseDown = new RelayCommand<MouseButtonEventArgs>(_chestMouseDownExecute);
                return _chestMouseDown;
            }
        }

        private void _chestMouseDownExecute(MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                _heroModel.Chest = null;
                RaisePropertyChanged("Defense");
                RaisePropertyChanged("ChestImage");
            }
        }

        private RelayCommand<DragEventArgs> _chestDrop;
        public RelayCommand<DragEventArgs> ChestDrop
        {
            get
            {
                if (_chestDrop == null)
                    _chestDrop = new RelayCommand<DragEventArgs>(chestDropExecute);

                return _chestDrop;
            }
        }

        private void chestDropExecute(DragEventArgs e)
        {
            ItemViewModel vm = e.Data.GetData(typeof(ItemViewModel)) as ItemViewModel;

            if (vm == null) return;

            ChestModel model = vm.Model as ChestModel;

            if (model == null) return;

            _heroModel.Chest = model;

            RaisePropertyChanged("Defense");
            RaisePropertyChanged("ChestImage");
        }

        private RelayCommand<MouseButtonEventArgs> _hatMouseDown;
        public RelayCommand<MouseButtonEventArgs> HatMouseDown
        {
            get
            {
                if (_hatMouseDown == null)
                    _hatMouseDown = new RelayCommand<MouseButtonEventArgs>(hatMouseDownExecute);
                return _hatMouseDown;
            }
        }

        private void hatMouseDownExecute(MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                _heroModel.Hat = null;
                RaisePropertyChanged("Defense");
                RaisePropertyChanged("HatImage");
            }
        }

        private RelayCommand<DragEventArgs> _hatDrop;
        public RelayCommand<DragEventArgs> HatDrop
        {
            get
            {
                if (_hatDrop == null)
                {
                    _hatDrop = new RelayCommand<DragEventArgs>(hatDropExecute);
                }
                return _hatDrop;
            }
        }

        private void hatDropExecute(DragEventArgs e)
        {
            ItemViewModel vm = e.Data.GetData(typeof(ItemViewModel)) as ItemViewModel;

            if (vm == null) return;

            HatModel model = vm.Model as HatModel;

            if (model == null) return;

            _heroModel.Hat = model;

            RaisePropertyChanged("Defense");
            RaisePropertyChanged("HatImage");

        }

        #endregion

        #region Ctor

        public HeroViewModel(HeroModel heroModel, IConnectionBd connection)
        {
            if (heroModel == null) throw new ArgumentNullException("heroModel");
            if (connection == null) throw new ArgumentNullException("connection");

            _heroModel = heroModel;
            _connection = connection;

            RaisePropertyChanged("HatImage");
            RaisePropertyChanged("WeaponImage");
            RaisePropertyChanged("ChestImage");
            RaisePropertyChanged("Attack");
            RaisePropertyChanged("Defense");
        }

        #endregion
    }
}
