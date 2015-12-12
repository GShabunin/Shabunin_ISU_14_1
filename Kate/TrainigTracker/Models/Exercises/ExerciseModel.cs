using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainigTracker.Models
{
    abstract class ExerciseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
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

        private string _type;
        public string ExerciseType
        {
            get { return _type; }
            set { _type = value; }
        }
        
        
    }
}
