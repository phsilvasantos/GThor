using System.Collections.Generic;
using System.Linq;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Implementacao.Base;

namespace GThorRepositorioEntityFramework.Implementacao
{
    internal class RepositorioUf : RepositorioBase, IRepositorioUf
    {
        public Uf CarregarPorId(int id)
        {
            return GThorContexto.Ufs.FirstOrDefault(uf => uf.Id == id);
        }

        public IEnumerable<Uf> Lista()
        {
            return GThorContexto.Ufs.ToList();
        }
    }
}