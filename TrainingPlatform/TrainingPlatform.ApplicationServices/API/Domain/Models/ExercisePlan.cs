using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.ApplicationServices.API.Domain.Models
{
    public class ExercisePlan
    {
        public int PlanId { get; set; }
        public int ExerciseId { get; set; }
        public Plan Plan { get; set; }
        public Exercise Exercise { get; set; }
    }
}
