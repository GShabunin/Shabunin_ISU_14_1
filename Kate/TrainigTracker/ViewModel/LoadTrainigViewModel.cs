using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MahApps.Metro.Controls;
using System.Windows.Controls;
using System.Windows;
using TrainigTracker.Models;
using TrainigTracker.Service;
using TrainigTracker.view;
using System.Collections.ObjectModel;

namespace TrainigTracker.ViewModel
{
    class LoadTrainigViewModel
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
            ListView list = window.FindName("TrainingList") as ListView;

            if (list == null) MessageBox.Show("Didn't find list");

            TrainingModel train = list.SelectedItem as TrainingModel;

            if (train == null)
                return;

            //_connection.Remove(train);
            //_heroes.Remove(train);
            //RaisePropertyChanged("Cardios");
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
            ListView list = window.FindName("HeroList") as ListView;

            if (list == null) MessageBox.Show("Didn't find list");

            TrainingModel train = list.SelectedItem as TrainingModel;

            if (train == null)
                return;

            TrainingHolder.Train = train;

            CreateNewTraining editorWindow = new CreateNewTraining();
            editorWindow.Show();
            window.Close();
        }

        #endregion

        #region PublicProps
        private ObservableCollection<TrainingModel> _trains;
        public ObservableCollection<TrainingModel> Trains
        {
            get
            {
                if (_trains == null)
                {
                    _trains = new ObservableCollection<TrainingModel>();

                   foreach (var z in _connection.Trains)
                       _trains.Add(z);
                }
                return _trains;
            }
        }

        #endregion

        #region PrivateFields

       private IConnectionBd _connection;

        #endregion

        #region ctor

        public LoadTrainigViewModel(IConnectionBd connection)
       {
           if (connection == null) throw new ArgumentNullException("connection");
           _connection = connection;
       }
        #endregion


    }
}
