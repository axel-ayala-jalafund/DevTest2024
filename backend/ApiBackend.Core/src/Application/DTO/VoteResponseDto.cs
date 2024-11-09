namespace ApiBackend.Core.src.Application.DTO;

public record VoteResponseDto(
    Guid Id,
    Guid PollId,
    Guid OptionId,
    string VoterEmail
);
