namespace ApiBackend.Core.src.Application.DTO;

public record CreateVoteDto(
    Guid OptionId,
    string VoterEmail
);