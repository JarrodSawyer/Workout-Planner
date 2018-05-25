using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workout_Planner.Models.Workout
{
    public class WorkoutDay
    {
        public int ID { get; set; }
        public int WorkoutID { get; set; }
        public int ExerciseID { get; set; }
        public int NumberSets { get; set; }
        public int GoalReps { get; set; }
        public double GoalWeight { get; set; }
        public double GoalWeightPercentage { get; set; }
        public double EstimatedOneRepMax { get; set; }
        public int GoalRPE { get; set; }
        public int ProgressionPercentage { get; set; }
        public int LastCompletedID { get; set; }
        public int ExerciseSequenceNum { get; set; }
    }
}
