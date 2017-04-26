using GThorFrameworkDominio.Dominios.Pessoas;
using GThorFrameworkDominio.Dto;
using GThorNegocio.Contratos.Base;

namespace GThorNegocio.Contratos
{
    public interface INegocioPessoa :
        INegocioSuporteGridModel<PessoaDto>,
        INegocioSalvar<Pessoa>,
        INegocioBase<Pessoa, int>
    {
        
    }
}