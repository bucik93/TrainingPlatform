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
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            this.CreateMap<AddUserRequest, User>()
                           .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName))
                           .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                           .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName));

            this.CreateMap<User, API.Domain.Models.User>()
                           .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                           .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName))
                           .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                           .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName));
        }
    }
}
