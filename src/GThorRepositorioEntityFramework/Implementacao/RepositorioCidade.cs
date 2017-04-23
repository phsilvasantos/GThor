using System.Collections.Generic;
using System.Linq;
using GThorFrameworkDominio.Dominios.Cidades;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Implementacao.Base;

namespace GThorRepositorioEntityFramework.Implementacao
{
    internal class RepositorioCidade : RepositorioBase, IRepositorioCidade
    {
        public Cidade CarregarPorId(int id)
        {
            return GThorContexto.Cidades.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Cidade> Lista()
        {
            return GThorContexto.Cidades.ToList();
        }
    }
}