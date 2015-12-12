using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingTrackerV2.DataBase.Xml
{
    class ConnectionXml : IConnectionDb
    {
        #region Public Properties

        public IList<Model.SportActivities.ITraining> Trainings
        {
            get 
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Public Properties

        public bool AddNewTraining(Model.SportActivities.ITraining training)
        {
            throw new NotImplementedException();
        }

        public bool RemoveTraining(Model.SportActivities.ITraining training)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTraining(Model.SportActivities.ITraining training)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
