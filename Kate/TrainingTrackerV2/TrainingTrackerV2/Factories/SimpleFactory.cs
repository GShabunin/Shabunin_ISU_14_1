using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTrackerV2.DataBase;
using TrainingTrackerV2.Model.SportActivities.Implementations;

namespace TrainingTrackerV2.Factories
{
    class SimpleFactory : IExerciseFactory
    {
        private IConnectionDb _connection;
        public SimpleFactory(IConnectionDb connection)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            _connection = connection;
        }
        public IList<BaseExerciseModel> Exercises
        {
            get
            {
                List<BaseExerciseModel> listSimple = new List<BaseExerciseModel>();
                foreach (var z in _connection.Exercises)
                {
                    if (z is SimpleExerciseModel)
                        listSimple.Add(z as SimpleExerciseModel);
                }
                return listSimple;
            }
        }
    }
}
