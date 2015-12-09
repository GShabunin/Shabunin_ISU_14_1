using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainigTracker.Service;
using TrainigTracker.Models.Exercises;

namespace TrainigTracker.Models.Factories
{
    class WeightExerciseFactory : IExerciseFactory
    {
        private IConnectionBd _connection;
        public WeightExerciseFactory(IConnectionBd connection)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            _connection = connection;
        }

        public IList<WeightExerciseModel> Weights
        {
            get
            {
                List<WeightExerciseModel> listWeight = new List<WeightExerciseModel>();

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
