using ApiBackend.Core.src.Application.DTO;
using FluentValidation;

namespace ApiBackend.API.src.Validators;

public class CreatePollValidator : AbstractValidator<CreatePollDto>
{
    public CreatePollValidator()
    {
        RuleFor(x => x.Name)
        .NotEmpty().WithMessage("Poll name is required");

        RuleFor(x => x.Options)
        .NotEmpty().WithMessage("Option are required");

        RuleForEach(x => x.Options).ChildRules(option => 
            option.RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Option name is required ")
        );
    }
}
