namespace ApiBackend.Core.src.Application.DTO;

public record PollDto
(
    Guid Id,
    string Name,
    ICollection<OptionDto> Options
);
