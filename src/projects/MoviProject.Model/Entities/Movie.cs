﻿

using Core.DataAccess.Entities;
using System.Reflection.Metadata;

namespace MoviProject.Model.Entities;

public sealed class Movie:Entity<Guid>
{
    public Movie()
    {
        Name=string.Empty;
        Description=string.Empty;
        ImageUrl=string.Empty;
        Category=new Category();
        MovieArtists=new HashSet<MovieArtist>();
        Directors=new Director();

    }
    public Movie(Guid id,
        string name,
        string description,
        double imdb,
        DateTime publish,
        string imageUrl,
        int categoryId,
        bool isActive,
        long directorId
        ):base(id)
    {
        Name = name;
        Description = description;
        IMDB = imdb;
        PublishTime = publish;
        ImageUrl = imageUrl;
        CategoryId = categoryId;
        IsActive = isActive;
        DirectorId = directorId;

        Category = new Category();
        MovieArtists = new HashSet<MovieArtist>();
        Directors = new Director();

    }

    public Movie(
        string name,
        string description,
        double imdb,
        DateTime publish,
        string imageUrl,
        int categoryId,
        bool isActive,
        long directorId
        ) :this(default,name, description, imdb, publish, imageUrl, categoryId, isActive,directorId)
    {}

    public string Name { get; set; }

    public string Description { get; set; }

    public double IMDB { get; set; }

    public DateTime PublishTime { get; set; }

    public string ImageUrl { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }

    public bool IsActive { get; set; }

    public ICollection<MovieArtist> MovieArtists { get; set; }

    public long DirectorId { get; set; }
    public Director Directors { get; set; }

}
