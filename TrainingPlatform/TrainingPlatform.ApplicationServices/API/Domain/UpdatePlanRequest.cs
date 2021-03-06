using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.ApplicationServices.API.Domain.Models;

namespace TrainingPlatform.ApplicationServices.API.Domain
{
    public class UpdatePlanRequest : IRequest<UpdatePlanResponse>
    {
        public int PlanId;
        public string Name { get; set; }
        public IList<ExercisePlan> ExercisePlans;

    }
}
