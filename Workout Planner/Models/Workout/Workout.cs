using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workout_Planner.Models.Workout
{
    public class Workout
    {
        public int ID { get; set; }
        public int ProgamWeekID { get; set; }
        public string Title { get; set; }
        public DateTime LastCompleted { get; set; }
    }
}
