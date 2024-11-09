using ApiBackend.Core.src.Domain.Entity;
using ApiBackend.Core.src.Domain.Interfaces.Repositories;
using ApiBackend.Infraestructure.src.Data.DbConnection.Interfaces;

namespace ApiBackend.Infraestructure.src.Repositories.DbRepository;

public class PollRepository : BaseRepository<Poll>, IPollRepository
{
    protected override string TableName => "polls";

    public PollRepository(IDbConnectionFactory connectionFactory) 
        : base(connectionFactory)
    {
    }

    public Task<Poll?> GetPollWithOptionAsync(Guid pollId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateOptionVotesAsyc(Guid optionsId)
    {
        throw new NotImplementedException();
    }
}
