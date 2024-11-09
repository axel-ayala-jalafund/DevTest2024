
namespace ApiBackend.Core.src.Domain.Entity;

public class Poll : IEntity
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Option> Options { get; set; } = new();
}
