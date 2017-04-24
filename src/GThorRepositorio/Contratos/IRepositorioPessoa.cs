using GThorFrameworkDominio.Dto;
using GThorFrameworkRepositorio.Contratos;
using GThorRepositorio.Contratos.Base;

namespace GThorRepositorio.Contratos
{
    public interface IRepositorioPessoa :
        IRepositorioContexto,
        ISuporteGridModel<PessoaDto>
    {
        
    }
}