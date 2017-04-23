using System;
using System.Collections.Generic;
using System.Linq;
using GThor.Views;
using GThorFrameworkBiblioteca.Ferramentas.HelpersHidratacaoValores;
using GThorFrameworkDominio.Dominios.Certificados;
using GThorFrameworkWpf.Models.DataGrid;
using GThorNegocio.Contratos;
using GThorNegocio.Criadores;
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
            IEnumerable<CertificadoDigital> listaFiltrada = null;

            if (pesquisarTexto.IsNotNullOrEmpty())
            {
                listaFiltrada = Cache.Where(c => c.Descricao.Contains(pesquisarTexto)).ToList();
            }

            if (pesquisarTexto.IsNullOrEmpty())
            {
                listaFiltrada = Cache.ToList();
            }

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
            var model = new CertificadoDigitalFormModel(NegocioCriador.CriaNegocioCertificadoDigital())
            {
                CertificadoDigital = new CertificadoDigital()
            };
            model.AtualizarListaHandler += AtualizarLista;

            var certificadoDigitalForm = new CertificadoDigitalForm(model);

            certificadoDigitalForm.ShowDialog();
        }

        public override void DuploClickDataGrid()
        {
            var model = new CertificadoDigitalFormModel(NegocioCriador.CriaNegocioCertificadoDigital())
            {
                CertificadoDigital = EntidadeSelecionada
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