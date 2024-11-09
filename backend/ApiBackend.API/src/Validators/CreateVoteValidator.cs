using ApiBackend.Core.src.Application.DTO;
using FluentValidation;

namespace ApiBackend.API.src.Validators;

public class CreateVoteValidator : AbstractValidator<CreateVoteDto>
{
    public CreateVoteValidator()
    {
        RuleFor(x => x.OptionId)
            .NotEmpty().WithMessage("Option ID is required");

        RuleFor(x => x.VoterEmail)
            .NotEmpty().WithMessage("Voter email is required")
            .EmailAddress().WithMessage("Invalid email format");
    }
}
