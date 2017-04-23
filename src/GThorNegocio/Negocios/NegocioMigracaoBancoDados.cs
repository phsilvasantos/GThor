using GThorNegocio.Contratos;
using GThorRepositorioEntityFramework.Criadores;
using Microsoft.EntityFrameworkCore;

namespace GThorNegocio.Negocios
{
    internal class NegocioMigracaoBancoDados : INegocioMigracaoBancoDados
    {
        public void Migrar()
        {
            using (var contexto = ContextoCriador.CriaContexto())
            {
                contexto.Database.Migrate();
            }
        }
    }
}