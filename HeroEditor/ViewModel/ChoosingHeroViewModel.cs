using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HeroEditor.Model;
using HeroEditor.Service;
using HeroEditor.Service.DataBases;
using HeroEditor.View.Windows;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HeroEditor.ViewModel
{
    class ChoosingHeroViewModel : ViewModelBase
    {
        #region Commands


        private RelayCommand<MetroWindow> _butDelete;
        public RelayCommand<MetroWindow> ButDelete
        {
            get
            {
                if (_butDelete == null)
                {
                    _butDelete = new RelayCommand<MetroWindow>(_butDeleteExecute);
                }
                return _butDelete;
            }
        }

        private void _butDeleteExecute(MetroWindow window)
        {
            ListView list = window.FindName("HeroList") as ListView;

            if (list == null) MessageBox.Show("Didn't find list");

            HeroModel hero = list.SelectedItem as HeroModel;

            if (hero == null)
                return;

            _connection.Remove(hero);
            _heroes.Remove(hero);
            RaisePropertyChanged("Heroes");
        }

        private RelayCommand<MetroWindow> _butEdit;
        public RelayCommand<MetroWindow> ButEdit
        {
            get
            {
                if (_butEdit == null)
                {
                    _butEdit = new RelayCommand<MetroWindow>(_butEditExecute);
                }
                return _butEdit;
            }
        }

        private void _butEditExecute(MetroWindow window)
        {
            ListView list =  window.FindName("HeroList") as ListView;

            if (list == null) MessageBox.Show("Didn't find list");

            HeroModel hero = list.SelectedItem as HeroModel;

            if (hero == null)
                return;

            HolderHeroModel.Hero = hero;

            HeroEditorWindow editorWindow = new HeroEditorWindow();
            editorWindow.Show();
            window.Close();
        }

        #endregion

        #region Public Properties

        private ObservableCollection<HeroModel> _heroes;
        public ObservableCollection<HeroModel> Heroes
        {
            get
            {
                if (_heroes == null)
                {
                    _heroes = new ObservableCollection<HeroModel>();

                    foreach (var z in _connection.Heroes)
                        _heroes.Add(z);
                }
                return _heroes;
            }
        }

        #endregion

        #region Private Fields

        private IConnectionBd _connection;

        #endregion

        #region ctor

        public ChoosingHeroViewModel(IConnectionBd connection)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            _connection = connection;
        }

        #endregion
    }
}
