using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainigTracker.Models;

namespace TrainigTracker.Service
{
    class TrainingHolder
    {
        protected static TrainingModel _trainingModel ;

        public static TrainingModel Train
        {
            get
            {
                if (_trainingModel == null)
                    _trainingModel = new TrainingModel();

                return _trainingModel;
            }
            set
            {
                _trainingModel = value;
            }
        }

        public static void CleanHeroModel()
        {
            Train = null;
        }
    }
}
