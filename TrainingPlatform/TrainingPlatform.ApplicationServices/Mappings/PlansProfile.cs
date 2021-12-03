using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.ApplicationServices.API.Domain.Models;

namespace TrainingPlatform.ApplicationServices.Mappings
{
    public class PlansProfile : Profile
    {
        public PlansProfile()
        {
            this.CreateMap<TrainingPlatform.DataAccess.Entities.Plan, Plan>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));

        }
    }
}