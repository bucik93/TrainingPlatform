using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.ApplicationServices.API.Domain
{
    public class ValidateUserRequest :IRequest<ValidateUserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
