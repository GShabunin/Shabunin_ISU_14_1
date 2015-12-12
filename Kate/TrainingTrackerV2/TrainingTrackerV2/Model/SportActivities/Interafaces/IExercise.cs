using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingTrackerV2.Model.SportActivities
{
    interface IExercise
    {
        string Name { get; set; }
        string Description { get; set; }

        bool Completed { get; }

        IList<TrainingTrackerV2.Model.SportActivities.Implementations.Repeat> Repeats { get; }

    }
}
