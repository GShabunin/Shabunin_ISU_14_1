using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTrackerV2.DataBase;
using TrainingTrackerV2.Model.SportActivities;
using TrainingTrackerV2.Model.SportActivities.Implementations;

namespace TrainingTrackerV2.Factories
{
    class WeightFactory : IExerciseFactory
    {
         private IConnectionDb _connection;
         public WeightFactory(IConnectionDb connection)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            _connection = connection;
        }
        public IList<BaseExerciseModel> Exercises
        {
            get
            {
                List<BaseExerciseModel> listWeight = new List<BaseExerciseModel>();
                foreach (var z in _connection.Exercises)
                {
                    if (z is WeightExerciseModel)
                        listWeight.Add(z as WeightExerciseModel);
                }
                return listWeight;
            }
        }
    }
}
