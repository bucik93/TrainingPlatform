using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.ApplicationServices.API.Domain
{
    public class AddPlanRequest : IRequest<AddPlanResponse>
    {
        public string Name { get; set; }

    }
}
