using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Workout_Planner.Models.Workout
{
    public class Program
    {
        public int ID { get; set; }

        [Display(Name = "Program Name"), Required(ErrorMessage = "Program Title is required")]
        public string Title { get; set; }

        [
         Display(Name = "Days per Week"), 
         Required(ErrorMessage = "Number of days per week is required"),
         Range(1, 7, ErrorMessage = "Number of days must be between 1 and 7!")
        ]
        public int DaysPerWeek { get; set; }

        [
         Display(Name = "Number of Weeks"), 
         Required(ErrorMessage = "Number of weeks is required"), 
         Range(1,16,ErrorMessage = "Number of weeks must be between 1 an 16!")
        ]
        public int NumberOfWeeks { get; set; }
    }
}
