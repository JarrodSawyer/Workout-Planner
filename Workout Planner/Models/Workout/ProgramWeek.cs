using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workout_Planner.Models.Workout
{
    public class ProgramWeek
    {
        public int ID { get; set; }
        public int ProgramID { get; set; }
        public string Title { get; set; }
        public int WeekSequenceNum { get; set; }
    }
}
