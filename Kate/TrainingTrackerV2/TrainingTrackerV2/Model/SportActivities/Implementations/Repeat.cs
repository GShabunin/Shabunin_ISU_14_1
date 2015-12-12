using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingTrackerV2.Model.SportActivities.Implementations
{
    class Repeat : INotifyPropertyChanged
    {
        #region Ctor

        public Repeat(int total)
        {
            Current = 0;
            Total = total;
        }

        #endregion

        #region Public Properties

        private int _current;
        public int Current
        {
            get { return _current; }
            set { _current = value; }
        }

        private int _total;
        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public bool Completed 
        {
            get 
            {
                return Total <= Current;
            }
        }


        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged (string propertyName)
        {
            if (propertyName == null) throw new ArgumentNullException("propertyName");

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}