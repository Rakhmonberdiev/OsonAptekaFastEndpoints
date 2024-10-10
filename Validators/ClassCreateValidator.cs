using FastEndpoints;
using FluentValidation;
using OsonAptekaFastEndpoints.RequestDtos.Classes;

namespace OsonAptekaFastEndpoints.Validators
{
    public class ClassCreateValidator:Validator<CreateClassReq>
    {
        public ClassCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1, 50);

        }
    }
}
