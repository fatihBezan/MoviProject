namespace MoviProject.Model.Dtos.Artists;

public sealed record ArtistResponseDto
{
    public long Id { get; init; }

    public string? ImageUrl { get; init; }

    public DateTime BirthDay { get; init; }

    public string? FullName { get; init; } 
}