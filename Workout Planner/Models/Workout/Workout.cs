using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Workout_Planner.Models.Workout
{
    public class Workout
    {
        public int ID { get; set; }
        public int ProgamWeekID { get; set; }

        [Display(Name = "Workout Name"), Required(ErrorMessage = "Program Title is required")]
        public string Title { get; set; }

        public DateTime LastCompleted { get; set; }
        public int WorkoutSequenceNum { get; set; }
    }
}
