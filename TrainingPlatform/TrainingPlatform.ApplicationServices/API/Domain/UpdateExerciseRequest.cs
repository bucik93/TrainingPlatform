using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.ApplicationServices.API.Domain
{
    public class UpdateExerciseRequest : IRequest<UpdateExerciseResponse>
    {
        public int ExerciseId;
        public string Name { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public int Series { get; set; }
        public int Repeat { get; set; }
        public int Weight { get; set; }

    }
}
