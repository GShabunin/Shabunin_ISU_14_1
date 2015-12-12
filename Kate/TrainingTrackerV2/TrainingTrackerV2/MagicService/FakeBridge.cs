using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrainingTrackerV2.Model.SportActivities;
using TrainingTrackerV2.Model.SportActivities.Implementations;

namespace TrainingTrackerV2.MagicService
{
    /// <summary>
    /// Тема тут такая. При разработке приложения мы ушли от реализации конкретного моста
    /// для работы с данными, подсунули данную заглушку. Вообще говоря я не знаю что такое заглушка
    /// просто на хабре подслушал, звучит здорово
    /// </summary>
    class FakeBridge : IDataBridge
    {

        #region Public Properties

        protected IList<ITraining> _trainings;
        public IList<Model.SportActivities.ITraining> Trainings
        {
            get 
            {
                if (_trainings == null)
                {
                    _trainings = new List<ITraining>();

                    _trainings.Add(new TrainingModel("Тренировка Максима", DateTime.Now));
                    _trainings.Add(new TrainingModel("Тренировка Максима", DateTime.Now));
                    _trainings.Add(new TrainingModel("Тренировка Максима", DateTime.Now));
                }
                return _trainings; 
            }
        }

        public Model.SportActivities.ITraining CurrentTraining
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Public Methods

        public void AddNewTraining(Model.SportActivities.ITraining training)
        {
            throw new NotImplementedException();
        }

        public void RemoveTraining(Model.SportActivities.ITraining training)
        {
            throw new NotImplementedException();
        }

        public void UpdateTrainging(Model.SportActivities.ITraining training)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
