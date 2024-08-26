using BananaDinner.Application.Common.Interfaces.Persistence;
using BananaDinner.Domain.MenuAggregate;

namespace BananaDinner.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Domain.MenuAggregate.Menu> _menus = [];
    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }
}
