using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTrackerV2.Model.SportActivities.Implementations;

namespace TrainingTrackerV2.Model.SportActivities
{
    class WeightExerciseModel : BaseExerciseModel
    {
        public WeightExerciseModel(string name, string description , IList<Repeat> repeats) 
            : base(name,description,repeats)
        { }

        public WeightExerciseModel(string name, string description, int weight = 0) 
            : base(name,description)
        {
            _weight = weight;
        }


        #region Public Properties

        private int _weight;
        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        

        #endregion
    }
}
