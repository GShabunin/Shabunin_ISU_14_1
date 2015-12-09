using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainigTracker.Models;
using TrainigTracker.Models.Exercises;

namespace TrainigTracker.Models
{
    class TrainingModel
    {
        public string Name { get; set; }
        public int? ID { get; set; }

        public CardioExerciseModel Cardio { get; set; }
        public WeightExerciseModel Weight { get; set; }
        public SimpleExerciseModel Simple { get; set; }
    }
}
