

using Microsoft.AspNetCore.Http;

namespace MoviProject.Model.Dtos.Artists;

public sealed record   ArtistAddRequestDto
{
    public string? Name { get; init; }

    public string? Surname { get; init; }

    public IFormFile? Image { get; init; }

    public DateTime BirthDay { get; init; }
}
