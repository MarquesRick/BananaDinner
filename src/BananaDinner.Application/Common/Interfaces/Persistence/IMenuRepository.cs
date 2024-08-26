namespace BananaDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Domain.MenuAggregate.Menu menu);
}
