using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.ApplicationServices.API.Domain.Models;

namespace TrainingPlatform.ApplicationServices.API.Domain
{
    public class AddExerciseToPlanRequest :IRequest<AddExerciseToPlanResponse>
    {
        public int PlanId { get; set; }
        public int ExerciseId { get; set; }
        //public Plan Plan { get; set; }
    }
}
