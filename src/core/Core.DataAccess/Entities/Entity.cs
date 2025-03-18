

namespace Core.DataAccess.Entities;

public abstract class Entity<TId>
{
    public TId Id { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public Entity()
    {
        Id = default;
        CreatedTime=DateTime.Now;
    }

    public Entity(TId id)
    {
        Id=id;
    }
}

