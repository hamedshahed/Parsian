namespace Parsian.DomainModel.Seedworks;

public abstract class Entity<TId>
{
    public virtual TId Id { get; protected set; }

    protected Entity()
    {
    }

    protected Entity(TId id)
    {
        Id = id;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Entity<TId> other))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (ValueObject.GetUnproxiedType(this) != ValueObject.GetUnproxiedType(other))
            return false;

        if (IsTransient() || other.IsTransient())
            return false;

        return Id.Equals(other.Id);
    }

    private bool IsTransient()
    {
        return Id is null || Id.Equals(default(TId));
    }

    public static bool operator ==(Entity<TId> a, Entity<TId> b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity<TId> a, Entity<TId> b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return (ValueObject.GetUnproxiedType(this).ToString() + Id).GetHashCode();
    }
}

public abstract class Entity : Entity<Guid>
{
    protected Entity()
    {
    }

    protected Entity(Guid id)
        : base(id)
    {
    }
}

//public abstract class Entity<TId> : IEquatable<Entity<TId>>
//{
//    private readonly TId id;

//    protected Entity(TId id)
//    {
//        if (object.Equals(id, default(TId)))
//        {
//            throw new ArgumentException("The ID cannot be the default value.", "id");
//        }

//        this.id = id;
//    }

//    public TId Id
//    {
//        get { return this.id; }
//    }

//    public override bool Equals(object obj)
//    {
//        var entity = obj as Entity<TId>;
//        if (entity != null)
//        {
//            return this.Equals(entity);
//        }
//        return base.Equals(obj);
//    }

//    public override int GetHashCode()
//    {
//        return this.Id.GetHashCode();
//    }

//    #region IEquatable<Entity> Members

//    public bool Equals(Entity<TId> other)
//    {
//        if (other == null)
//        {
//            return false;
//        }
//        return this.Id.Equals(other.Id);
//    }

//    #endregion
//}