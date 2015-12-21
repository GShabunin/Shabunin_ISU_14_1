using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTrackerV2.MagicService;
using TrainingTrackerV2.Model.SportActivities;
using TrainingTrackerV2.DataBase;
using TrainingTrackerV2.Model.SportActivities.Implementations;

namespace TrainingTrackerV2.ViewModel
{
    class AddNewTrainingViewModel : ViewModelBase
    {
        #region NonPublic Fields

        IDataBridge _bridge;
        IConnectionDb _connection;

        #endregion

        #region Ctor

        public AddNewTrainingViewModel(IDataBridge bridge)
        {
            if (bridge == null) throw new ArgumentNullException("bridge");

            _bridge = bridge;
        }

        #endregion 

        #region Public Properties

        protected ObservableCollection<IExercise> _exercises;
        public ObservableCollection<IExercise> Exercises
        {
            get
            {
               if (null == _exercises)
               {
                   _exercises = new ObservableCollection<IExercise>();
               }
               return _exercises;
            }
        }


        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        
        
        


        #endregion

        #region Commands
        private RelayCommand _butSimple;

        public RelayCommand butSimple
        {
            get
            {
                if (_butSimple == null)
                {
                    _butSimple = new RelayCommand(butSimpleExecute);
                }
                return _butSimple;

            }
        }
            public void butSimpleExecute()
            {
                _exercises.Add(new SimpleExerciseModel("New Simple Exercise", "Description"));
                RaisePropertyChanged("Exercises");
            }
        

        private RelayCommand _butAddWeight;
        public RelayCommand ButAddWeight
        {
            get
            {
                if (_butAddWeight == null)
                {
                    _butAddWeight = new RelayCommand(butAddWeightExecute);
                }
                return _butAddWeight;
            }
        }

        private void butAddWeightExecute()
        {
            _exercises.Add(new WeightExerciseModel("New Weight Exercise", "Description"));
            RaisePropertyChanged("Exercises");
        }

        private RelayCommand _butDelete;
        public RelayCommand ButDelete
        {
            get
            {
                if (_butDelete == null)
                {
                    _butDelete = new RelayCommand(butDeleteExecute);
                }
                return _butDelete;
            }
        }

        private void butDeleteExecute()
        {
            if (Exercises.Count != 0)
            {
                Exercises.RemoveAt(Exercises.Count-1);
                RaisePropertyChanged("Exercises");
            }
        }

        private RelayCommand _butCardio;

        public RelayCommand ButCardio
        {
            get
            {
                if (_butCardio == null)
                {
                    _butCardio = new RelayCommand(butAddCardioExecute);
                }
                return _butCardio;
            }
        }
        private void butAddCardioExecute()
        {
             _exercises.Add(new CardioExerciseModel("New Cardio Exercise", "Description"));
            RaisePropertyChanged("Exercises");
        }

        #endregion
    }
}
