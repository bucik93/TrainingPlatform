using AutoMapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.ApplicationServices.API.Domain;
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.ApplicationServices.Mappings
{
    public class PlansProfile : Profile
    {
        public PlansProfile()
        {
            this.CreateMap<AddPlanRequest, Plan>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));

            this.CreateMap<UpdatePlanRequest, Plan>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.PlanId))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));

            this.CreateMap<RemovePlanRequest, Plan>()
                 .ForMember(x => x.Id, y => y.MapFrom(z => z.PlanId));

            this.CreateMap<Plan, API.Domain.Models.Plan>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Exercises, y => y.MapFrom(z => z.ExercisePlans.Select(x=>x.Exercise).ToList()))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));


        }
    }
}