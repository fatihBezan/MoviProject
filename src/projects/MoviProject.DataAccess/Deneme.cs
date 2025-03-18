

using MoviProject.Model.Entities;

namespace MoviProject.DataAccess;

public class Deneme
{
    public void Dene()
    {
        //kısıtlama yapmadığı için ilgili alanlar kaçırılabilir,Hata vermez.
        Movie movie = new Movie()
        {
            Id=Guid.NewGuid(),
            CategoryId=1,
            CreatedTime = DateTime.Now,
        };


        //kullanıcıdan zorunlu olarak almak istediğin verileri güncelleme  işlemi yaparken kullanmam gerekir
        Movie movie1 = new Movie(Guid.NewGuid(),"Deneme"," ", 15,DateTime.Now,"img.jpg",2,false,1 );

        //kullanıcıdan zorunlu olarak almak istediğin verileri ekleme işlemi yaparken kullanmam gerekir
        Movie movie2 = new Movie( "Deneme", " ", 15, DateTime.Now, "img.jpg", 2, false, 1);

    }
}
