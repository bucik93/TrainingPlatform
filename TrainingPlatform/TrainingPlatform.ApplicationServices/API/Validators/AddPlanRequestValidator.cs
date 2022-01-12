using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.ApplicationServices.API.Domain;

namespace TrainingPlatform.ApplicationServices.API.Validators
{
    public class AddPlanRequestValidator : AbstractValidator<AddPlanRequest>
    {
        public AddPlanRequestValidator()
        {
            this.RuleFor(x => x.Name).MaximumLength(100)
                .NotNull();
        }
    }
}
