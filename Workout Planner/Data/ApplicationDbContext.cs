using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Workout_Planner.Models;
using Workout_Planner.Models.Workout;

namespace Workout_Planner.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Workout_Planner.Models.Workout.Program> Program { get; set; }

        public DbSet<Workout_Planner.Models.Workout.ProgramWeek> ProgramWeek { get; set; }

        public DbSet<Workout_Planner.Models.Workout.Workout> Workout { get; set; }

        public DbSet<Workout_Planner.Models.Workout.WorkoutDay> WorkoutDay { get; set; }

        public DbSet<Workout_Planner.Models.Workout.Exercise> Exercise { get; set; }
    }
}
