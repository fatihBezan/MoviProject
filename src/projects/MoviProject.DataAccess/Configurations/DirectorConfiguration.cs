

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviProject.Model.Entities;

namespace MovieProject.DataAccess.Configurations;

public sealed class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.ToTable("Director_db").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("DirectorId").IsRequired();
        builder.Property(x => x.CreatedTime).HasColumnName("Created").IsRequired();

        builder.HasMany(x=>x.Movies).WithOne(x=>x.Directors).HasForeignKey(x=>x.DirectorId);

        builder.HasData(
            
            new Director
            {
                Id=1,
                BirthDay = DateTime.Parse("1959-02-09 16:39:25.0000000"),
                CreatedTime=DateTime.UtcNow,
                ImageUrl= "https://www.hollywoodreporter.com/movies/movie-news/legend-of-the-croisette-nuri-bilge-ceylan-cannes2023-1235502380/",
                Name="Nuri bilge",
                Surname="Ceylan"
            }

            );
    }
}
