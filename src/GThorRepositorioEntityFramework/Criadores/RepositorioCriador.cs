using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Implementacao;

namespace GThorRepositorioEntityFramework.Criadores
{
    public static class RepositorioCriador
    {
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

        public static IRepositorioUsuario CriaRepositorioUsuario()
        {
            return new RepositorioUsuario();
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
    }
}