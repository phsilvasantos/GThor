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
            return GThorContexto.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Usuario> Lista()
        {
            var lista = GThorContexto.Usuarios.Take(1000).ToList();

            return lista;
        }

        public void SalvarOuAtualizar(Usuario entity)
        {
            if (entity.Id == 0)
            {
                GThorContexto.Usuarios.Add(entity);
                return;
            }

            GThorContexto.Usuarios.Update(entity);
        }

        public void Deletar(Usuario entity)
        {
            GThorContexto.Usuarios.Remove(entity);
        }
    }
}