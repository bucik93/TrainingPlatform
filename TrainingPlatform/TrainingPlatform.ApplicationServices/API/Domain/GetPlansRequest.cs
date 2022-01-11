using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.ApplicationServices.API.Domain.Models;

namespace TrainingPlatform.ApplicationServices.API.Domain
{
    public class GetPlansRequest : IRequest<GetPlansResponse>
    {
        public string Name { get; set; }
    }
}
