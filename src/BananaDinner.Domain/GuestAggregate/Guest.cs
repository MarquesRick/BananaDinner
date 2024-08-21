using BananaDinner.Domain.Common.Models;
using BananaDinner.Domain.GuestAggregate.ValueObjects;

namespace BananaDinner.Domain.GuestAggregate;

public sealed class Guest : AggregateRoot<GuestId>
{
    public Guest(GuestId id)
        : base(id)
    {
    }
}
