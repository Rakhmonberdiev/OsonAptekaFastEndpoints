using FastEndpoints;
using FluentValidation;
using OsonAptekaFastEndpoints.RequestDtos.Classes;

namespace OsonAptekaFastEndpoints.Validators
{
    public class ClassUpdateValidator : Validator<UpdateClassReq>
    {
        public ClassUpdateValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1, 50);
        }
    }
}
