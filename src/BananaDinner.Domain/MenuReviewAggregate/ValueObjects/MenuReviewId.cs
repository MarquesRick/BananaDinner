using BananaDinner.Domain.Common.Models;

namespace BananaDinner.Domain.MenuReviewAggregate.ValueObjects;
public sealed class MenuReviewId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private MenuReviewId(Guid value)
    {
        Value = value;
    }

    public static MenuReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuReviewId Create(Guid value)
    {
        return new MenuReviewId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private MenuReviewId()
    {
    }
}
