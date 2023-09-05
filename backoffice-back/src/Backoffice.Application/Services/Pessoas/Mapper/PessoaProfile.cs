using AutoMapper;
using Backoffice.Application.Services.Pessoas.Responses;
using Backoffice.Domain.Entities;

namespace Backoffice.Application.Services.Pessoas.Mapper;

public class PessoaProfile : Profile
{
    public PessoaProfile()
    {
        CreateMap<Pessoa, BuscarPessoasJuridicasResponse>()
            .ForMember(x => x.Id, x => x.MapFrom(x => x.Id))
            .ForMember(x => x.Qualificacao, x => x.MapFrom(x => x.Qualificacao.ToString()))
            .ForMember(x => x.RazaoSocial, x => x.MapFrom(x => x.PessoaJuridica.RazaoSocial))
            .ForMember(x => x.NomeFantasia, x => x.MapFrom(x => x.PessoaJuridica.NomeFantasia))
            .ForMember(x => x.Cnpj, x => x.MapFrom(x => x.PessoaJuridica.Cnpj.Valor))
            .ForMember(x => x.Cep, x => x.MapFrom(x => x.Endereco.Cep))
            .ForMember(x => x.Rua, x => x.MapFrom(x => x.Endereco.Rua))
            .ForMember(x => x.Numero, x => x.MapFrom(x => x.Endereco.Numero))
            .ForMember(x => x.Bairro, x => x.MapFrom(x => x.Endereco.Bairro))
            .ForMember(x => x.Cidade, x => x.MapFrom(x => x.Endereco.Cidade))
            .ForMember(x => x.Estado, x => x.MapFrom(x => x.Endereco.Estado))
            .ForMember(x => x.CriadoEm, x => x.MapFrom(x => x.CreatedAt))
            .ForMember(x => x.AtualizadoEm, x => x.MapFrom(x => x.UpdatedAt));

        CreateMap<Pessoa, BuscarPessoaFisicaResponse>()
            .ForMember(x => x.Id, x => x.MapFrom(x => x.Id))
            .ForMember(x => x.Qualificacao, x => x.MapFrom(x => x.Qualificacao.ToString()))
            .ForMember(x => x.Apelido, x => x.MapFrom(x => x.PessoaFisica.Apelido))
            .ForMember(x => x.Nome, x => x.MapFrom(x => x.PessoaFisica.Nome))
            .ForMember(x => x.Cpf, x => x.MapFrom(x => x.PessoaFisica.Cpf.Valor))
            .ForMember(x => x.Cep, x => x.MapFrom(x => x.Endereco.Cep))
            .ForMember(x => x.Rua, x => x.MapFrom(x => x.Endereco.Rua))
            .ForMember(x => x.Numero, x => x.MapFrom(x => x.Endereco.Numero))
            .ForMember(x => x.Bairro, x => x.MapFrom(x => x.Endereco.Bairro))
            .ForMember(x => x.Cidade, x => x.MapFrom(x => x.Endereco.Cidade))
            .ForMember(x => x.Estado, x => x.MapFrom(x => x.Endereco.Estado))
            .ForMember(x => x.CriadoEm, x => x.MapFrom(x => x.CreatedAt))
            .ForMember(x => x.AtualizadoEm, x => x.MapFrom(x => x.UpdatedAt));

        CreateMap<Pessoa, BuscarPessoasColaboradorasResponse>()
            .ForMember(x => x.Documento,
                x => x.MapFrom(x => x.PessoaFisica == null ? x.PessoaJuridica.Cnpj.Valor : x.PessoaFisica.Cpf.Valor))
            .ForMember(x => x.NomeRazaoSocial,
                x => x.MapFrom(x => x.PessoaFisica == null ? x.PessoaJuridica.RazaoSocial : x.PessoaFisica.Nome));
    }
}