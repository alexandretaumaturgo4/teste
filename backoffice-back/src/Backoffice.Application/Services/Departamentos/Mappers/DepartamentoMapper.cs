using AutoMapper;
using Backoffice.Application.Services.Departamentos.Responses;
using Backoffice.Domain.Entities;

namespace Backoffice.Application.Services.Departamentos.Mappers;

public class DepartamentoMapper : Profile
{
    public DepartamentoMapper()
    {
        CreateMap<Departamento, BuscarDepartamentoResponse>()
            .ForMember(x => x.Nome, x => x.MapFrom(x => x.Nome))
            .ForMember(x => x.NomeResponsavel,
                x => x.MapFrom(x =>
                    x.Responsavel.PessoaFisica == null
                        ? x.Responsavel.PessoaJuridica.RazaoSocial
                        : x.Responsavel.PessoaFisica.Nome));
    }
}