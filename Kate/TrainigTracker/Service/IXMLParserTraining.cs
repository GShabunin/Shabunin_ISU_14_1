using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainigTracker.Models;

namespace TrainigTracker.Service
{
    interface IXMLParserTraining
    {
        TrainingModel parseTraining(string pathToTraining, IEnumerable<ExerciseModel> exercises);
    }
}
