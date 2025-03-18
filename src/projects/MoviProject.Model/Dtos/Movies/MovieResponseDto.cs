﻿

using Microsoft.AspNetCore.Http;

namespace MoviProject.Model.Dtos.Movies;

public sealed record MovieResponseDto
{
    public Guid Id { get; init; }

    public string? Name { get; init; }

    public string? Description { get; init; }

    public double IMDB { get; init; }

    public DateTime PublishTime { get; init; }

    public IFormFile? Image { get; init; }

    public string? CategoryName { get; init; }

    public bool IsActive { get; init; }

    public string? DirectorName { get; init; }
}
