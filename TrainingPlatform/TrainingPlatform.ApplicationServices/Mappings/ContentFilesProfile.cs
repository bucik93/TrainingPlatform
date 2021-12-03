using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.ApplicationServices.API.Domain.Models;

namespace TrainingPlatform.ApplicationServices.Mappings
{
    public class ContentFilesProfile : Profile
    {
        public ContentFilesProfile()
        {
            this.CreateMap<TrainingPlatform.DataAccess.Entities.ContentFile, ContentFile>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.FileContent, y => y.MapFrom(z => z.FileContent))
                .ForMember(x => x.File, y => y.MapFrom(z => z.File));
        }
    }
}