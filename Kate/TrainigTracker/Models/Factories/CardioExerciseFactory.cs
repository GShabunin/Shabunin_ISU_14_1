using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainigTracker.Service;
using TrainigTracker.Models.Exercises;

namespace TrainigTracker.Models.Factories
{
    class CardioExerciseFactory: IExerciseFactory
    {
        private IConnectionBd _connection;
        public CardioExerciseFactory(IConnectionBd connection)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            _connection = connection;
        }

        public IList<CardioExerciseModel> Cardios
        {
            get
            {
                List<CardioExerciseModel> listCardio = new List<CardioExerciseModel>();

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
