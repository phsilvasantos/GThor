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
    }
}