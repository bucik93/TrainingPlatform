using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.ApplicationServices.API.Domain
{
    public class RemoveUserRequest : IRequest<RemoveUserResponse>
    {
        public int UserId { get; set; }
    }
}
