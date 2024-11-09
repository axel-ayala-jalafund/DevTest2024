namespace ApiBackend.Core.src.Domain.Entity;

public class Option : IEntity
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int Votes { get; set; }
    public Guid PollId { get; set; }
    public Poll? Poll { get; set; }
}
