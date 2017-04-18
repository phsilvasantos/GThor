using System;
using System.Linq;
using System.Windows.Data;
using GThor.Views;
using GThorFrameworkBiblioteca.Ferramentas.HelpersCriptografia;
using GThorFrameworkDominio.Dominios.Certificados;
using GThorFrameworkWpf.Models.DataGrid;
using GThorNegocio.Contratos;
using GThorNegocio.Negocios;
using GThorRepositorioEntityFramework.Implementacao;

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
            AdicionarDataGridColumn(() => certificadoDigital.Descricao);
        }

        protected override void DeletarRegistroSelecionado()
        {
            _certificadoDigitalNegocio.Deletar(EntidadeSelecionada);
        }

        public override void NovoRegistroAction(object obj)
        {
            var model = new CertificadoDigitalFormModel(new CertificadoDigitalNegocio(new RepositorioCertificadoDigital()))
            {
                CertificadoDigital = new CertificadoDigital()
            };
            model.AtualizarListaHandler += AtualizarLista;

            var certificadoDigitalForm = new CertificadoDigitalForm(model);

            certificadoDigitalForm.ShowDialog();
        }

        private void AtualizarLista(object sender, EventArgs e)
        {
            IniciaPesquisa(PesquisarTexto);
        }
    }
}