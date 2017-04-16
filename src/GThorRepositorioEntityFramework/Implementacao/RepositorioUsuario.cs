using System.Collections.Generic;
using System.Linq;
using GThorFrameworkDominio.Dominios.Usuarios;
using GThorRepositorioEntityFramework.Contratos;
using GThorRepositorioEntityFramework.Implementacao.Base;

namespace GThorRepositorioEntityFramework.Implementacao
{
    public class RepositorioUsuario : RepositorioBase, IRepositorioUsuario
    {
        public Usuario CarregarPorId(int id)
        {
            return GThorContexto.Usuario.Find(id);
        }

        public IList<Usuario> Lista()
        {
            var lista = GThorContexto.Usuario.Take(1000).ToList();

            return lista;
        }

        public void Dispose()
        {
            GThorContexto.Dispose();
        }

        public void SalvarOuAtualizar(Usuario entity)
        {
            GThorContexto.Usuario.Add(entity);
        }

        public void Deletar(Usuario entity)
        {
            GThorContexto.Usuario.Remove(entity);
        }
    }
}