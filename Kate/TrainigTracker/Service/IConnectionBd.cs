using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainigTracker.Models;

namespace TrainigTracker.Service
{
 interface IConnectionBd
    {  
        IList<TrainingModel> Trains { get;}
        IList<ExerciseModel> Exercises { get; }
        bool Save(TrainingModel train);
        bool Remove(TrainingModel train);
        bool Update(TrainingModel train);
        bool Update(int IDTRAIN);
     


    }
}
