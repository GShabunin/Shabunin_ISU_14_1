using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingTrackerV2.Model.SportActivities.Implementations
{
    class SimpleExerciseModel: BaseExerciseModel
    {
        public SimpleExerciseModel(string name, string description , IList<Repeat> repeats) 
            : base(name,description,repeats)
        { }

        public SimpleExerciseModel(string name, string description) 
            : base(name,description)
        {
         
        }
    }
}
