using System;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkRepositorio.Contratos;

namespace GThorRepositorio.Contratos
{
    public interface IRepositorioUf :
        IDaoContexto,
        IDaoBase<Uf, int>,
        IDisposable
    {
        
    }
}