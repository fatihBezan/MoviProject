

using Microsoft.AspNetCore.Http;

namespace MoviProject.Model.Dtos.Directors;

public sealed record DirectorAddRequestDto
{
    public string? Name { get; init; }

    public string? Surname { get; init; }

    public IFormFile? Image { get; init; }

    public DateTime BirthDay { get; init; }
}

