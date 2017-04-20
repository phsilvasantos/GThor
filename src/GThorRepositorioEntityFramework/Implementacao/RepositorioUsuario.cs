using System.Collections.Generic;
using System.Linq;
using GThorFrameworkDominio.Dominios.Usuarios;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Implementacao.Base;

namespace GThorRepositorioEntityFramework.Implementacao
{
    public class RepositorioUsuario : RepositorioBase, IRepositorioUsuario
    {
        public Usuario CarregarPorId(int id)
        {
            return GThorContexto.Usuario.Find(id);
        }

        public IEnumerable<Usuario> Lista()
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
            if (entity.Id == 0)
            {
                GThorContexto.Usuario.Add(entity);
                return;
            }

            GThorContexto.Usuario.Update(entity);
        }

        public void Deletar(Usuario entity)
        {
            GThorContexto.Usuario.Remove(entity);
        }
    }
}