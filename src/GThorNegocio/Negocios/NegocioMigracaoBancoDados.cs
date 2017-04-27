using GThorMigracaoBancoDados;
using GThorNegocio.Contratos;

namespace GThorNegocio.Negocios
{
    internal class NegocioMigracaoBancoDados : INegocioMigracaoBancoDados
    {
        public void Migrar()
        {
            new ExecutaMigracao().Executa();
        }
    }
}