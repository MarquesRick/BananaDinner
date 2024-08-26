using ErrorOr;
using MediatR;

namespace BananaDinner.Application.Menu.Commands.CreateMenu;

public record CreateMenuCommand(
    string HostId,
    string Name,
    string Description,
    List<MenuSectionCommand> Sections
) : IRequest<ErrorOr<Domain.MenuAggregate.Menu>>;

public record MenuSectionCommand(
    string Name,
    string Description,
    List<MenuItemCommand> Items
);

public record MenuItemCommand(
    string Name,
    string Description
);
