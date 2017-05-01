using GThorRepositorio.Contratos;
using GThorRepositorioNHibernate.Imeplementacoes;

namespace GThorRepositorioNHibernate.Criadores
{
    public static class RepositorioCriador
    {
        public static IRepositorioUsuario CriaRepositorioUsuario()
        {
            return new RepositorioUsuario();
        }

        public static IRepositorioCertificadoDigital CriaRepositorioCertificadoDigital()
        {
            return new RepositorioCertificadoDigital();
        }

        public static IRepositorioDocumentoMdfe CriaRepositorioDocumentoMdfe()
        {
            return new RepositorioDocumentoMdfe();
        }

        public static IRepositorioUf CriaRepositorioUf()
        {
            return new RepositorioUf();
        }

        public static IRepositorioVeiculo CriaRepositorioVeiculo()
        {
            return new RepositorioVeiculo();
        }

        public static IRepositorioCidade CriaRepositorioCidade()
        {
            return new RepositorioCidade();
        }

        public static IRepositorioEmpresa CriaRepositorioEmpresa()
        {
            return new RepositorioEmpresa();
        }

        public static IRepositorioPessoa CriaRepositorioPessoa()
        {
            return new RepositorioPessoa();
        }

        public static IRepositorioPerfilMdfe CriaRepositorioPerfilMdfe()
        {
            return new RepositorioPerfilMdfe();
        }
    }
}