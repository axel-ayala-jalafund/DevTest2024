using ApiBackend.Core.src.Domain.Entity;
using ApiBackend.Core.src.Domain.Interfaces.Repositories;
using ApiBackend.Infraestructure.src.Data.Memory;

namespace ApiBackend.Infraestructure.src.Repositories.BaseMemoryRepository;

public class PollMemoryRepository : BaseMemoryRepository<Poll>, IPollRepository
{
    public PollMemoryRepository(MemoryContext context) 
        : base(context)
    {
    }

    public async Task<Poll?> GetPollWithOptionAsync(Guid pollId)
    {
        var poll = await GetByIdAsync(pollId);

        if (poll == null)
        {
            return null;
        } 

        poll.Options = _context.Options
            .Where(o => o.PollId == pollId)
            .ToList();

        return poll;
    }

    public async Task<bool> UpdateOptionVotesAsyc(Guid optionsId)
    {
        var option = _context.Options.FirstOrDefault(o => o.Id == optionsId);

        if (option == null)
        {
            return await Task.FromResult(false);
        } 

        option.Votes++;
        return await Task.FromResult(true);
    }

    protected override List<Poll> GetDbSet()
    {
        return _context.Polls;
    }
}
