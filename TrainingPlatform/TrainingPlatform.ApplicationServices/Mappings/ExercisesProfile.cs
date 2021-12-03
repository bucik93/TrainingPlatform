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
                 .ForMember(x => x.File, y => y.MapFrom(z => z.File))
                 .ForMember(x => x.Series, y => y.MapFrom(z => z.Series))
                 .ForMember(x => x.Repeat, y => y.MapFrom(z => z.Repeat))
                 .ForMember(x => x.Weight, y => y.MapFrom(z => z.Weight))
                 .ForMember(x => x.Time, y => y.MapFrom(z => z.Time))
                 .ForMember(x => x.OneHanded, y => y.MapFrom(z => z.OneHanded))
                 .ForMember(x => x.BothHands, y => y.MapFrom(z => z.BothHands));
        }
    }
}
