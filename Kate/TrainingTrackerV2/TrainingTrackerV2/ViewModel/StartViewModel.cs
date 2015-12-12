using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System;
using TrainingTrackerV2.MagicService;
using System.Collections.ObjectModel;
using TrainingTrackerV2.Model.SportActivities;
using TrainingTrackerV2.View.Windows;

namespace TrainingTrackerV2.ViewModel
{
    class StartViewModel : ViewModelBase
    {
        #region NonPublic Fields

        IDataBridge _bridge;

        #endregion

        #region Ctor

        public StartViewModel(IDataBridge bridge)
        {
            if (bridge == null) throw new ArgumentNullException("bridge");

            _bridge = bridge;
        }

        #endregion

        #region Public Properties

        protected ObservableCollection<ITraining> _trainings;
        public ObservableCollection<ITraining> Trainings
        {
            get
            {
                if (_trainings == null)
                {
                    _trainings = new ObservableCollection<ITraining>();

                    foreach (var z in _bridge.Trainings)
                    {
                        _trainings.Add(z);
                    }
                }

                return _trainings;
            }
        }
       
        #endregion 

        #region Commands

        private RelayCommand _butCreateNewTraining;
        public RelayCommand ButCreateNewTraining
        {
            get
            {
                if (_butCreateNewTraining == null)
                {
                    _butCreateNewTraining = new RelayCommand(butCreateNewTrainingExecute);
                }
                return _butCreateNewTraining;
            }
        }

        private void butCreateNewTrainingExecute()
        {
         //   MessageBox.Show("Lera has little boobs");

            AddNewTrainingWindow newWindow = new AddNewTrainingWindow();
            newWindow.ShowDialog();
        }

        #endregion
    }
}