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

        public int? ID { get; set; }

        private string _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        
        
    }
}
