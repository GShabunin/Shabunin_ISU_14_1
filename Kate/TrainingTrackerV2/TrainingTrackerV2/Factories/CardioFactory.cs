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
    class CardioFactory: IExerciseFactory
    {
        
         private IConnectionDb _connection;
         public CardioFactory(IConnectionDb connection)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            _connection = connection;
        }
        public IList<BaseExerciseModel> Exercises
        {
            get
            {
                List<BaseExerciseModel> listCardio = new List<BaseExerciseModel>();
                foreach (var z in _connection.Exercises)
                {
                    if (z is CardioExerciseModel)
                        listCardio.Add(z as CardioExerciseModel);
                }
                return listCardio;
            }
        }
    }
}
