using GThorNegocio.Contratos;
using GThorRepositorioEntityFramework.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GThorNegocio.Negocios
{
    public class NegocioMigracaoBancoDados : INegocioMigracaoBancoDados
    {
        public void Migrar()
        {
            using (var contexto = new GThorContexto())
            {
                contexto.Database.Migrate();
            }
        }
    }
}