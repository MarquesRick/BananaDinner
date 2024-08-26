namespace BananaDinner.Contracts.Menu;

public record CreateMenuRequest(
    string Name,
    string Description,
    List<MenuSection> Sections
);

public record MenuSection(
    string Name,
    string Description,
    List<MenuItems> Items
);

public record MenuItems(
    string Name,
    string Description
);
