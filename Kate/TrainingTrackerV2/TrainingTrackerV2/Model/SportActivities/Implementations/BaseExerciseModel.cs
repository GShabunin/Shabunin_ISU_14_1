using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingTrackerV2.Model.SportActivities.Implementations
{
    abstract class BaseExerciseModel : IExercise
    {
        #region Ctor

        public BaseExerciseModel(string name, string description , IList<Repeat> repeats)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("name is empty");
            if (description == null) throw new ArgumentNullException("description");
            if (repeats == null) throw new ArgumentNullException("repeats");

            _name = name;
            _description = description;
            _repeats = repeats;
        }

        public BaseExerciseModel(string name, string description)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("name is empty");
            if (description == null) throw new ArgumentNullException("description");
        
            _name = name;
            _description = description;
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

        protected string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        public bool Completed
        {
            get
            {
                foreach (var z in Repeats)
                {
                    if (z.Completed == false) return false;
                }

                return true;
            }
        }

        protected IList<Repeat> _repeats;
        public IList<Repeat> Repeats
        {
            get
            {
                if (_repeats == null) throw new InvalidOperationException("_repeats is null");

                return _repeats;
            }
        }

        #endregion
    }
}
