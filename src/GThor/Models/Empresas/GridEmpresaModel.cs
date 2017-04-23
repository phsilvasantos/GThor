using System;
using System.Linq;
using GThor.Views.Empresas;
using GThorFrameworkBiblioteca.Ferramentas.HelpersHidratacaoValores;
using GThorFrameworkDominio.Dominios.Empresas;
using GThorFrameworkDominio.Dto;
using GThorFrameworkWpf.Models.DataGrid;
using GThorNegocio.Contratos;
using GThorNegocio.Criadores;

namespace GThor.Models.Empresas
{
    public class GridEmpresaModel : DataGridPadraoModel<EmpresaDto>
    {
        private readonly INegocioEmpresa _negocioEmpresa;

        public GridEmpresaModel(INegocioEmpresa negocioEmpresa)
        {
            _negocioEmpresa = negocioEmpresa;
        }

        public override void BuscarRegistros()
        {
            Cache = _negocioEmpresa.BuscarParaGridModel();
            PreencherLista(Cache);
        }

        public override void AplicaPesquisa(string pesquisarTexto)
        {
            if (pesquisarTexto.IsNotNullOrEmpty())
            {
                var listaFiltrada = Cache.Where(e => e.Id.ToString() == pesquisarTexto
                                                     || e.NomeFantasia.Contains(pesquisarTexto)
                                                     || e.RazaoSocial.Contains(pesquisarTexto)
                                                     || e.Cnpj == pesquisarTexto).ToList();
                PreencherLista(listaFiltrada);
                return;
            }

            PreencherLista(Cache.ToList());
        }

        public override void CriarColunas()
        {
            EmpresaDto empresaDto = null;
            AdicionarDataGridColumn(() => empresaDto.Id);
            AdicionarDataGridColumn(() => empresaDto.RazaoSocial);
            AdicionarDataGridColumn(() => empresaDto.NomeFantasia);
            AdicionarDataGridColumn(() => empresaDto.Cnpj);
        }

        public override void NovoRegistroAction(object obj)
        {
            var model = new EmpresaFormModel(NegocioCriador.CriaNegocioEmpresa()) {Empresa = new Empresa()};

            model.AtualizarListaHandler += AtualizarLista;

            new EmpresaForm(model).ShowDialog();
        }

        private void AtualizarLista(object sender, EventArgs e)
        {
            IniciaPesquisa(PesquisarTexto);
        }
    }
}