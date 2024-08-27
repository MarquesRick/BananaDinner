using BananaDinner.Application.Common.Interfaces.Persistence;
using BananaDinner.Domain.MenuAggregate;

namespace BananaDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly BananaDinnerDbContext _dbContext;

    public MenuRepository(BananaDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Menu menu)
    {
        _dbContext.Add(menu);
        _dbContext.SaveChanges();
    }
}
