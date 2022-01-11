using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.ApplicationServices.API.Domain;
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.ApplicationServices.Mappings
{
    public class ExercisePlanProfile :Profile
    {
        public ExercisePlanProfile()
        {
            this.CreateMap<AddExerciseToPlanRequest, DataAccess.Entities.ExercisePlan>()
                .ForMember(x => x.ExerciseId, y => y.MapFrom(z => z.ExerciseId))            
                .ForMember(x => x.PlanId, y => y.MapFrom(z => z.PlanId));

            this.CreateMap<ExercisePlan, API.Domain.Models.ExercisePlan>()
                 .ForMember(x => x.ExerciseId, y => y.MapFrom(z => z.ExerciseId))
                 .ForMember(x => x.PlanId, y => y.MapFrom(z => z.PlanId));

        }
    }
}
