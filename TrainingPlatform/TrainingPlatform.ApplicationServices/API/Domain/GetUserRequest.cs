using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.ApplicationServices.API.Domain
{
    public class GetUserRequest: IRequest<GetUserResponse>
    {
        public string UserName { get; set; }
    }
}
