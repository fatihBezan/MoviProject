using Core.DataAccess.Entities;

namespace MoviProject.Model.Entities;

public sealed class Artist:Entity<long>
{
    public Artist()
    {
        Name=string.Empty;
        Surname=string.Empty;
        ImageUrl=string.Empty;
        MovieArtists=new HashSet<MovieArtist>();   
    }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string ImageUrl { get; set; }

    public DateTime BirthDay { get; set; }

    public ICollection<MovieArtist> MovieArtists { get; set; }


}
