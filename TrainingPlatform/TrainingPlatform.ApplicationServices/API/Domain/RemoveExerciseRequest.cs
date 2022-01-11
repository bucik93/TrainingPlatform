using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.ApplicationServices.API.Domain
{
    public class RemoveExerciseRequest : IRequest<RemoveExerciseResponse>
    {
        public int ExerciseId { get; set; }
    }
}