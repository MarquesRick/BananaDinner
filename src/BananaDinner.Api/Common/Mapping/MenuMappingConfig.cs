using BananaDinner.Application.Menu.Commands.CreateMenu;
using BananaDinner.Contracts.Menu;
using BananaDinner.Domain.MenuAggregate;
using Mapster;

namespace BananaDinner.Api.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.AverageRating, src => src.AverageRating.Value)
            .Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(x => x.Value))
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(x => x.Value));

        config.NewConfig<Domain.MenuAggregate.Entities.MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<Domain.MenuAggregate.Entities.MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}
