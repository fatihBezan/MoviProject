using Core.DataAccess.Entities;

namespace MoviProject.Model.Entities;

//ara tablo 
public sealed class MovieArtist:Entity<long>
{
    public MovieArtist()
    {
        Artists = new Artist();
        Movies=new Movie();
    }



    public long ArtistId { get; set; }

    public Artist Artists { get; set; }

    public Guid MovieId { get; set; }

    public Movie Movies { get; set; }

}
