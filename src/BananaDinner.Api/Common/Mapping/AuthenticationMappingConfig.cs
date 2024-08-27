using BananaDinner.Application.Authentication.Commands.Register;
using BananaDinner.Application.Authentication.Common;
using BananaDinner.Application.Authentication.Queries.Login;
using BananaDinner.Contracts.Authentication;
using BananaDinner.Domain.UserAggregate;
using Mapster;

namespace BananaDinner.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);
    }
}
