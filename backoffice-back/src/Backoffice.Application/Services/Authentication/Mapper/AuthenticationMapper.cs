using AutoMapper;
using Backoffice.Application.Services.Authentication.Responses;
using Microsoft.AspNetCore.Identity;

namespace Backoffice.Application.Services.Authentication.Mapper;

public class AuthenticationMapper : Profile
{
    public AuthenticationMapper()
    {
        CreateMap<IdentityUser, BuscarUsuarioResponse>()
            .ForMember(x => x.Ativo, x => x.MapFrom(x => x.EmailConfirmed));
    }
}