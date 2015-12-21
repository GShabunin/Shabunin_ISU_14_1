using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTrackerV2.Model.SportActivities.Implementations;

namespace TrainingTrackerV2.Factories
{
    interface IExerciseFactory
    {
        IList<BaseExerciseModel> Exercises { get; }
    }
}
