export interface PessoaFisicaModelRequest extends BasePessoaRequest {
  nome: string;
  apelido: string;
  cpf: string;
}

export interface PessoaJuridicaModelRequest extends BasePessoaRequest {
  razaoSocial: string;
  nomeFantasia: string;
  cnpj: string;
}

export interface BasePessoaRequest {
  qualificacao: number;
  cep: string;
  rua: string;
  numero: string;
  bairro: string;
  cidade: string;
  estado: string;
}

export interface PessoaJuridica {
  razaoSocial: string;
  nomeFantasia: string;
  cnpj: string;
  id: string;
  qualificacao: string;
  cep: string;
  rua: string;
  numero: string;
  bairro: string;
  cidade: string;
  estado: string;
}


export interface PessoaFisica {
  nome: string;
  apelido: string;
  cpf: string;
  id: string;
  qualificacao: string;
  cep: string;
  rua: string;
  numero: string;
  bairro: string;
  cidade: string;
  estado: string;
}
