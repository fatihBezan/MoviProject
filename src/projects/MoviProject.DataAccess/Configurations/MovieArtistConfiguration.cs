

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviProject.Model.Entities;

namespace MovieProject.DataAccess.Configurations;

public sealed class MovieArtistConfiguration : IEntityTypeConfiguration<MovieArtist>
{
    public void Configure(EntityTypeBuilder<MovieArtist> builder)
    {
        builder.ToTable("MovieArtist_db").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("MovieArtistId").IsRequired();
        builder.Property(x => x.CreatedTime).HasColumnName("Created").IsRequired();

        builder.HasOne(x=>x.Artists).WithMany(x=>x.MovieArtists)
            .HasForeignKey(x=>x.ArtistId);

        builder.HasOne(x=>x.Movies).WithMany(x=> x.MovieArtists)    
            .HasForeignKey(x => x.MovieId);

    }
}
