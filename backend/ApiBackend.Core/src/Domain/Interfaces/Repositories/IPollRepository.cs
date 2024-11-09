using ApiBackend.Core.src.Domain.Entity;

namespace ApiBackend.Core.src.Domain.Interfaces.Repositories;

public interface IPollRepository : IRepository<Poll>
{
    Task<Poll> GetPollWithOptionAsync(Guid pollId);
    Task<bool> UpdateOptionVotesAsyc(Guid optionsId);
}
