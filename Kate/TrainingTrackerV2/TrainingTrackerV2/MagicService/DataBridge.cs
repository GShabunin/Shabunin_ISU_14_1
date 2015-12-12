using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTrackerV2.DataBase;
using TrainingTrackerV2.Model.SportActivities;

namespace TrainingTrackerV2.MagicService
{
    class DataBridge : IDataBridge, INotifyPropertyChanged
    {
        #region NonPublic Fields

        IConnectionDb _connection;

        #endregion

        #region Ctor

        public DataBridge(IConnectionDb connection)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            
            _connection = connection;
        }

        #endregion

        #region Public Properties

        IList<ITraining> _trainings;
        public IList<ITraining> Trainings
        {
            get 
            {
                if (_trainings == null)
                {
                    _trainings = _connection.Trainings;

                    if (_trainings == null) throw new InvalidOperationException("_trainings is null");
                }

                return _trainings; 
            }
        }

        ITraining _currentTraining;
        public ITraining CurrentTraining
        {
            get
            {
                return _currentTraining;
            }
            set
            {
                _currentTraining = value;
            }
        }

        #endregion

        #region Public Methods

        public void AddNewTraining(ITraining training)
        {
            throw new NotImplementedException();
        }

        public void RemoveTraining(ITraining training)
        {
            throw new NotImplementedException();
        }

        public void UpdateTrainging(ITraining training)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string nameProperty)
        {
            if (nameProperty == null) throw new ArgumentNullException("nameProperty");

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nameProperty));
        }

        #endregion
    }
}
