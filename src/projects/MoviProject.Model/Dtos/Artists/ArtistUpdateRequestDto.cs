

using Microsoft.AspNetCore.Http;

namespace MoviProject.Model.Dtos.Artists;

//record - record miras alabilir
//record - class miras alamaz
//record - interface miras alır

public sealed record ArtistUpdateRequestDto
{
    public long Id { get; init; }

    public string? Name { get; init; }

    public string? Surname { get; init; }

    public IFormFile? Image { get; init; }

    public DateTime BirthDay { get; init; }

    public string? FullName { get; init; }

}
