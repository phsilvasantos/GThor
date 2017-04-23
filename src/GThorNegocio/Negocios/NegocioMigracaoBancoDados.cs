using GThorNegocio.Contratos;
using GThorRepositorioEntityFramework.Criadores;

namespace GThorNegocio.Negocios
{
    internal class NegocioMigracaoBancoDados : INegocioMigracaoBancoDados
    {
        public void Migrar()
        {
            using (var contexto = ContextoCriador.CriaContexto())
            {
                contexto.MigrarBancoDados();
            }
        }
    }
}