namespace ApiBackend.Core.src.Application.DTO;

public record CreatePollDto(
    string Name,
    ICollection<CreateOptionDto> Options
);