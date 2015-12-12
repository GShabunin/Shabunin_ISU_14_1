using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTrackerV2.Model.SportActivities;

namespace TrainingTrackerV2.MagicService
{
    interface IDataBridge
    {
        IList<ITraining> Trainings { get; }

        ITraining CurrentTraining { get; set; }

        void AddNewTraining(ITraining training);
        void RemoveTraining(ITraining training);
        void UpdateTrainging(ITraining training);
    }
}
