using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTrackerV2.Model.SportActivities.Implementations;

namespace TrainingTrackerV2.Model.SportActivities
{
    class TrainingModel : ITraining
    {
        #region Ctor

        public TrainingModel(string name, DateTime datePlanned)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("name is empty");

            _name = name;
            _datePlanned = datePlanned;
        }

        public TrainingModel(string name, IList<IExercise> exercises, DateTime datePlanned)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("name is empty");

            if (exercises == null) throw new ArgumentNullException("exercises");

            _name = name;
            _datePlanned = datePlanned;
            _exercises = exercises;
        }

        #endregion 

        #region Public Properties

        protected string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        protected DateTime _datePlanned;
        public DateTime DatePlanned
        {
            get
            {
                return _datePlanned;
            }
            set
            {
                _datePlanned = value;
            }
        }

        protected int? _id;
        public int? ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public bool Completed
        {
            get 
            {
                foreach (var z in Exercises)
                    if (z.Completed == false) return false;

                return true;
            }
        }

        protected IList<IExercise> _exercises;
        public IList<IExercise> Exercises
        {
            get 
            {
                return _exercises;
            }
        }

        #endregion
    }
}
