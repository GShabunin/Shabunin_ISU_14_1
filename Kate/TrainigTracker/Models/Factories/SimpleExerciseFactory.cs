using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainigTracker.Service;
using TrainigTracker.Models.Exercises;

namespace TrainigTracker.Models.Factories
{
    class SimpleExerciseFactory : IExerciseFactory
    {
        private IConnectionBd _connection;
        public SimpleExerciseFactory(IConnectionBd connection)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            _connection = connection;
        }

        public IList<SimpleExerciseModel> Simples
        {
            get
            {
                List<SimpleExerciseModel> listSimple = new List<SimpleExerciseModel>();

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
