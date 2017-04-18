using System.Linq;
using GThorFrameworkDominio.Dominios.Certificados;
using GThorFrameworkWpf.Models.DataGrid;
using GThorNegocio.Contratos;

namespace GThor.Models.CertificadoDigitais
{
    public class GridCertificadoDigitalModel : DataGridPadraoModel<CertificadoDigital>
    {
        private readonly ICertificadoDigitalNegocio _certificadoDigitalNegocio;

        public GridCertificadoDigitalModel(ICertificadoDigitalNegocio certificadoDigitalNegocio)
        {
            _certificadoDigitalNegocio = certificadoDigitalNegocio;
            BotaoFiltroVisivel = false;
        }

        public override void BuscarRegistros()
        {
            Cache = _certificadoDigitalNegocio.Lista();
            PreencherLista(Cache);
        }

        public override void AplicaPesquisa(string pesquisarTexto)
        {
            var listaFiltrada = Cache.ToList();

            PreencherLista(listaFiltrada);
        }

        public override void CriarColunas()
        {
            CertificadoDigital certificadoDigital = null;
            AdicionarDataGridColumn(() => certificadoDigital.Id, 40);
            AdicionarDataGridColumn(() => certificadoDigital.Tipo);
            AdicionarDataGridColumn(() => certificadoDigital.Serial);
            AdicionarDataGridColumn(() => certificadoDigital.CaminhoCertificado);
        }

        protected override void DeletarRegistroSelecionado()
        {
            _certificadoDigitalNegocio.Deletar(EntidadeSelecionada);
        }
    }
}