using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using TrainigTracker.Models;
using TrainigTracker.Models.Exercises;
using TrainigTracker.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TrainigTracker.ViewModel
{
    class TrainingViewModel : ViewModelBase
    {
        private TrainingModel _trainingModel;
        private IConnectionBd _connection;

        public string Name
        {
            get
            {
                return _trainingModel.Name;
            }
            set
            {
                _trainingModel.Name = value;
                RaisePropertyChanged("Name");
            }
        }

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
            _connection.Save(_trainingModel);
        }

        public TrainingViewModel (TrainingModel trainingModel, IConnectionBd connection)
        {
            if (trainingModel == null) throw new ArgumentNullException("trainingModel");
            if (connection == null) throw new ArgumentNullException("connection");

            _trainingModel = trainingModel;
            _connection = connection;

        }
    }
}
