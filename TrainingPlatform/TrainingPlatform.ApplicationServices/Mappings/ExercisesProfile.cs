using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.ApplicationServices.API.Domain.Models;

namespace TrainingPlatform.ApplicationServices.Mappings
{
    public class ExercisesProfile : Profile
    {
        public ExercisesProfile()
        {
            this.CreateMap<TrainingPlatform.DataAccess.Entities.Exercise, Exercise>()
                 .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                 .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                 .ForMember(x => x.Link, y => y.MapFrom(z => z.Link))
                 .ForMember(x => x.Series, y => y.MapFrom(z => z.Series))
                 .ForMember(x => x.Repeat, y => y.MapFrom(z => z.Repeat))
                 .ForMember(x => x.Weight, y => y.MapFrom(z => z.Weight));
               
        }
    }
}
