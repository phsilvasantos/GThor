using GThorNegocio.Contratos;
using GThorNegocio.Negocios;
using GThorRepositorioEntityFramework.Implementacao;

namespace GThorNegocio.Criadores
{
    public static class NegocioCriador
    {
        public static INegocioCertificadoDigital CriaNegocioCertificadoDigital()
        {
            return new NegocioCertificadoDigital(new RepositorioCertificadoDigital());
        }

        public static INegocioDocumentoMdfe CriaNegocioDocumentoMdfe()
        {
            return new NegocioDocumentoMdfe(new RepositorioDocumentoMdfe());
        }

        public static INegocioUf CriaNegocioUf()
        {
            return new NegocioUf(new RepositorioUf());
        }

        public static INegocioUsuario CriaNegocioUsuario()
        {
            return new NegocioUsuario(new RepositorioUsuario());
        }

        public static INegocioVeiculo CriaNegocioVeiculo()
        {
            return new NegocioVeiculo(new RepositorioVeiculo());
        }

        public static INegocioMigracaoBancoDados CriaNegocioMigracaoBancoDados()
        {
            return new NegocioMigracaoBancoDados();
        }
    }
}