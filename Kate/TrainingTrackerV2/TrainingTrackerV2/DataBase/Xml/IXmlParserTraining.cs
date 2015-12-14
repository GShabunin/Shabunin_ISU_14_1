using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTrackerV2.Model;
using TrainingTrackerV2.Model.SportActivities;
using TrainingTrackerV2.Model.SportActivities.Implementations;


namespace TrainingTrackerV2.DataBase.Xml
{
    interface IXmlParserTraining
    {
         TrainingModel parseTraining(string pathToTraining, IEnumerable<BaseExerciseModel> exercises);

    }
}
