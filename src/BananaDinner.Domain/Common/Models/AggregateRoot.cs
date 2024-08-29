namespace BananaDinner.Domain.Common.Models;
public class AggregateRoot<TId, TIdType> : Entity<TId>
    where TId : AggregateRootId<TIdType>
{
#pragma warning disable CA1061
    public new AggregateRootId<TIdType> Id { get; protected set; }
    protected AggregateRoot(TId id)
    {
        Id = id;
    }
#pragma warning restore CA1061

#pragma warning disable CS8618
    protected AggregateRoot()
    {
    }
#pragma warning restore CS8618
}
