using ApiBackend.Core.src.Application.DTO;
using ApiBackend.Core.src.Domain.Entity;
using ApiBackend.Core.src.Domain.Interfaces.Repositories;
using ApiBackend.Core.src.Domain.Interfaces.Services;
using FluentValidation;

namespace ApiBackend.Core.src.Application.Services;

public class PollService : IPollService
{
    private readonly IPollRepository _pollRepository;

    private readonly IValidator<CreatePollDto> _createPollValidator;
    private readonly IValidator<CreateVoteDto> _createVoteValidator;

    public PollService(
        IPollRepository pollRepository,
        IValidator<CreatePollDto> createPollValidator,
        IValidator<CreateVoteDto> createVoteValidator
    )
    {
        _pollRepository = pollRepository;
        _createPollValidator = createPollValidator;
        _createVoteValidator = createVoteValidator;
    }

    public async Task<PollDto> CreatePollAsync(CreatePollDto createPollDto)
    {
        var validationResult = await _createPollValidator.ValidateAsync(createPollDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var poll = new Poll
        {
            Name = createPollDto.Name,
            CreatedAt = DateTime.UtcNow,
            Options = createPollDto.Options
                .Select(o => new Option
                {
                    Name = o.Name,
                    Votes = 0
                }).ToList()
        };

        await _pollRepository.CreateAsync(poll);
        return MapToDto(poll);
    }

    public async Task<IEnumerable<PollDto>> GetAllPollAsync()
    {
        var polls = await _pollRepository.GetAllAsync();
        return polls.Select(MapToDto);
    }

    public Task<VoteResponseDto> VoteAsync(Guid pollId, CreateVoteDto voteDto)
    {
        throw new NotImplementedException();
    }

    private static PollDto MapToDto(Poll poll) =>
        new(
            poll.Id,
            poll.Name,
            poll.Options.Select(o => new OptionDto(o.Id, o.Name, o.Votes)).ToList()
        );
}
