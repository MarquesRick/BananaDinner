using BananaDinner.Application.Common.Interfaces.Persistence;
using BananaDinner.Domain.HostAggregate.ValueObjects;
using BananaDinner.Domain.MenuAggregate.Entities;
using ErrorOr;
using MediatR;

namespace BananaDinner.Application.Menu.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Domain.MenuAggregate.Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Domain.MenuAggregate.Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Create Menu
        var menu = Domain.MenuAggregate.Menu.Create(
            name: request.Name,
            description: request.Description,
            hostId: HostId.CreateUnique(), // TODO: verificar depois
            sections: request.Sections.ConvertAll(sections => MenuSection.Create(
                name: sections.Name,
                description: sections.Description,
                items: sections.Items.ConvertAll(items => MenuItem.Create(
                    name: items.Name,
                    description: items.Description)))));

        // Persist Menu
        _menuRepository.Add(menu);
        return menu;
    }
}
