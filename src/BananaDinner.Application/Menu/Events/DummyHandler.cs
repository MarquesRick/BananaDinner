using BananaDinner.Domain.MenuAggregate.Events;
using MediatR;

namespace BananaDinner.Application.Menu.Events;

public class DummyHandler : INotificationHandler<MenuCreated>
{
    public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
