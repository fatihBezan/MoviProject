

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviProject.Model.Entities;

namespace MovieProject.DataAccess.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies_db").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("MovieId").IsRequired();
        builder.Property(x => x.CreatedTime).HasColumnName("Created").IsRequired();

        builder.HasOne(x=>x.Directors)
            .WithMany(x => x.Movies)
            .HasForeignKey(x => x.DirectorId);

        builder.HasOne(x => x.Category)
            .WithMany(x => x.Movies)
            .HasForeignKey(x => x.CategoryId);

        builder.HasMany(x => x.MovieArtists)
            .WithOne( x => x.Movies)
            .HasForeignKey(x => x.MovieId);

        builder.Navigation(x => x.Directors).AutoInclude();
        builder.Navigation(x=>x.Category).AutoInclude();
    }

}
