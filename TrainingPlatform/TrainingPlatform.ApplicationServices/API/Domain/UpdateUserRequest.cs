using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.ApplicationServices.API.Domain
{
    public class UpdateUserRequest : IRequest<UpdateUserResponse>
    {
        public int Id;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string HashedPassword;
        public string Salt;

    }
}
