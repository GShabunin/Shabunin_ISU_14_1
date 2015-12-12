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

namespace TrainingTrackerV2.ViewModel
{
    class AddNewTrainingViewModel : ViewModelBase
    {
        #region NonPublic Fields

        IDataBridge _bridge;

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
        
        
        

        public string TestProperty 
        { 
            get
            {
                return "Не смотря на то, что у Леры маленькие сиськи я все равно хочу ее выебать";
            }
        }

        #endregion

        #region Commands

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

        #endregion
    }
}
