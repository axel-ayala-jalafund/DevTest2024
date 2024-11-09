using ApiBackend.Core.src.Application.DTO;

namespace ApiBackend.Core.src.Domain.Interfaces.Services;

public interface IPollService
{
    Task<IEnumerable<PollDto>> GetAllPollAsync();
    Task<PollDto> CreatePollAsync(CreatePollDto createPollDto);
    Task<VoteResponseDto> VoteAsync(Guid pollId, CreateVoteDto voteDto);
}
