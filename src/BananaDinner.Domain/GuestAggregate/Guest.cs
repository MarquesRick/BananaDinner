using BananaDinner.Domain.Common.Models;
using BananaDinner.Domain.GuestAggregate.ValueObjects;

namespace BananaDinner.Domain.GuestAggregate;

public sealed class Guest : AggregateRoot<GuestId>
{
    public Guest(GuestId id)
        : base(id)
    {
    }

#pragma warning disable CS8618
    private Guest()
    {
    }
#pragma warning restore CS8618
}
