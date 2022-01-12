using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.ApplicationServices.API.Domain;

namespace TrainingPlatform.ApplicationServices.API.Validators
{
    public class UpdateExerciseRequestValidator : AbstractValidator<UpdateExerciseRequest>
    {
        public UpdateExerciseRequestValidator()
        {
            this.RuleFor(x => x.Name).MaximumLength(100)
                .NotNull();
            this.RuleFor(x => x.Link).MaximumLength(150)
                .NotNull();
            this.RuleFor(x => x.Series).InclusiveBetween(1,100).NotNull();
            this.RuleFor(x => x.Repeat).InclusiveBetween(1, 100).NotNull();
            this.RuleFor(x => x.Weight).InclusiveBetween(1, 300).NotNull();
        }
    }
}