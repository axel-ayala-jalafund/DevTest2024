using ApiBackend.Core.src.Domain.Entity;

namespace ApiBackend.Infraestructure.src.Data.Memory;

public class MemoryContext
{
    public List<Poll> Polls { get; set; } = new();
    public List<Option> Options { get; set; } = new();
    public List<Vote> Votes { get; set; } = new ();

    public MemoryContext() 
    {

    }

    private void Data()
    {
        var poll1 = new Poll
        {   
            Id = Guid.NewGuid(),
            Name = "Favorite programming language",
            CreatedAt = DateTime.UtcNow
        };


        var option1 = new Option
        {
            Id = Guid.NewGuid(),
            Name = "C#",
            Votes = 150,
            PollId = poll1.Id
        };

        var option2 = new Option
        {
            Id = Guid.NewGuid(),
            Name = "Javascript",
            Votes = 200,
            PollId = poll1.Id
        };

        poll1.Options.Add(option1);
        poll1.Options.Add(option2);

        Polls.Add(poll1);
        
    }
}

