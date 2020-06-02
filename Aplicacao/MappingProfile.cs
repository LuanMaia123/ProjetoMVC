using AutoMapper;
using Dominio.Entidades;
using Dominio.Modelos;

namespace Application.Fornecedores
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Fornecedor, FornecedorModel>();
            CreateMap<Empresa, EmpresaModel>();
            CreateMap<Telefone, TelefoneModel>();
            CreateMap<FornecedorModel, Fornecedor>();
            CreateMap<EmpresaModel, Empresa>();
            CreateMap<TelefoneModel, Telefone>();
        }
    }
}