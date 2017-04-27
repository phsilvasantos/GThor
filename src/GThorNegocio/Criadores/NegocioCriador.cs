using GThorNegocio.Contratos;
using GThorNegocio.Negocios;
using GThorRepositorioEntityFramework.Criadores;

namespace GThorNegocio.Criadores
{
    public static class NegocioCriador
    {
        public static INegocioCertificadoDigital CriaNegocioCertificadoDigital()
        {
            return new NegocioCertificadoDigital(GThorRepositorioNHibernate.Criadores.RepositorioCriador.CriaRepositorioCertificadoDigital());
        }

        public static INegocioDocumentoMdfe CriaNegocioDocumentoMdfe()
        {
            return new NegocioDocumentoMdfe(RepositorioCriador.CriaRepositorioDocumentoMdfe());
        }

        public static INegocioUf CriaNegocioUf()
        {
            return new NegocioUf(RepositorioCriador.CriaRepositorioUf());
        }

        public static INegocioUsuario CriaNegocioUsuario()
        {
            return new NegocioUsuario(GThorRepositorioNHibernate.Criadores.RepositorioCriador.CriaRepositorioUsuario());
        }

        public static INegocioVeiculo CriaNegocioVeiculo()
        {
            return new NegocioVeiculo(RepositorioCriador.CriaRepositorioVeiculo());
        }

        public static INegocioMigracaoBancoDados CriaNegocioMigracaoBancoDados()
        {
            return new NegocioMigracaoBancoDados();
        }

        public static INegocioCidade CriaNegocioCidade()
        {
            return new NegocioCidade(RepositorioCriador.CriaRepositorioCidade());
        }

        public static INegocioEmpresa CriaNegocioEmpresa()
        {
            return new NegocioEmpresa(RepositorioCriador.CriaRepositorioEmpresa());
        }

        public static INegocioPessoa CriaNegocioPessoa()
        {
            return new NegocioPessoa(RepositorioCriador.CriaRepositorioPessoa());
        }
    }
}