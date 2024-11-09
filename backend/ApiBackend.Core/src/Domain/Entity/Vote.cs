namespace ApiBackend.Core.src.Domain.Entity;

public class Vote : IEntity
{
    public Guid Id { get; set; }
    public Guid Poll { get; set; }
    public Guid OptionId { get; set; }
    public string? VoterEmail { get; set; } = string.Empty;
    public DateTime VoteAt { get; set; }
}
