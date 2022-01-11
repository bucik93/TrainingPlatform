using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlatform.ApplicationServices.API.Domain
{
    public class SearchPlanNameRequest : IRequest<SearchPlanNameResponse>
    {
        public string Name { get; set; }
    }
}
