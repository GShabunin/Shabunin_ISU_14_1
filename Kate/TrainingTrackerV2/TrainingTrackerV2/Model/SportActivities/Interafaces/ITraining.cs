using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingTrackerV2.Model.SportActivities
{
    interface ITraining
    {
        string Name { get; set; }
        DateTime DatePlanned { get; set; }
        
        int? ID { get; set; }
        bool Completed { get; }
        
        IList<IExercise> Exercises { get; }
    }
}
