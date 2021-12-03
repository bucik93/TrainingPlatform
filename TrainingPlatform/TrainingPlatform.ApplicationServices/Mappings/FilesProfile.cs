using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.ApplicationServices.API.Domain.Models;

namespace TrainingPlatform.ApplicationServices.Mappings
{
    public class FilesProfile : Profile
    {
        public FilesProfile()
        {
            this.CreateMap<TrainingPlatform.DataAccess.Entities.File, File>()
                 .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                 .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                 .ForMember(x => x.Extension, y => y.MapFrom(z => z.Extension));
        }
    }
}

