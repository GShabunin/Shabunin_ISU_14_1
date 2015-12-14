using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTrackerV2.Model.SportActivities.Implementations;

namespace TrainingTrackerV2.DataBase.Xml
{
    interface IXmlParserExercise
    {
        BaseExerciseModel GetExerciseModelFromXml(string ContentXml);
    }
}
