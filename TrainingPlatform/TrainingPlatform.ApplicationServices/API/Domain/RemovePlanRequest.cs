using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.ApplicationServices.API.Domain
{
    public class RemovePlanRequest :IRequest<RemovePlanResponse>
    {
        public int PlanId { get; set; }
    }
}
