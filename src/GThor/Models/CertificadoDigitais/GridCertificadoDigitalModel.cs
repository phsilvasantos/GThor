using System;
using System.Linq;
using GThor.Views;
using GThorFrameworkDominio.Dominios.Certificados;
using GThorFrameworkWpf.Models.DataGrid;
using GThorNegocio.Contratos;
using GThorNegocio.Negocios;
using GThorRepositorioEntityFramework.Implementacao;

namespace GThor.Models.CertificadoDigitais
{
    public class GridCertificadoDigitalModel : DataGridPadraoModel<CertificadoDigital>
    {
        private readonly INegocioCertificadoDigital _certificadoDigitalNegocio;

        public GridCertificadoDigitalModel(INegocioCertificadoDigital certificadoDigitalNegocio)
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
            AdicionarDataGridColumn(() => certificadoDigital.Tipo, 150);
            AdicionarDataGridColumn(() => certificadoDigital.Descricao);
        }

        protected override void DeletarRegistroSelecionado()
        {
            _certificadoDigitalNegocio.Deletar(EntidadeSelecionada);
        }

        public override void NovoRegistroAction(object obj)
        {
            var model = new CertificadoDigitalFormModel(new NegocioCertificadoDigital(new RepositorioCertificadoDigital()))
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