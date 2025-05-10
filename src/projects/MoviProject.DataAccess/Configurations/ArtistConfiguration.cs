

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviProject.Model.Entities;

namespace MovieProject.DataAccess.Configurations
{
    public sealed class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artist_db").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ArtistId").IsRequired();
            builder.Property(x => x.CreatedTime).HasColumnName("Created").IsRequired();
            builder.Property(x=>x.Name).HasColumnName("ArtistName").IsRequired();

            builder.HasMany(x => x.MovieArtists);

         
        }
    }
}
