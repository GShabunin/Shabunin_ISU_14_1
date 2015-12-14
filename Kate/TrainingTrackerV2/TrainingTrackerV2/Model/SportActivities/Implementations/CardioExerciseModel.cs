using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingTrackerV2.Model.SportActivities.Implementations
{
    class CardioExerciseModel: BaseExerciseModel
    {
        public CardioExerciseModel(string name, string description , IList<Repeat> repeats) 
            : base(name,description,repeats)
        { }

        public CardioExerciseModel(string name, string description, int time = 0) 
            : base(name,description)
        {
            _time = time;
        }


        #region Public Properties

        private int _time;
        public int Time
        {
            get { return _time; }
            set { _time = value; }
        }
        

        #endregion
    }
}
