using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows;
using GThor.Models.MdfeFiscal.Abas;
using GThorFrameworkComponentes.ComboBox.EstadosUFs;
using GThorFrameworkDominio.Dominios.EstadosUf;

namespace GThor.Views.MdfeFiscal
{
    public partial class MdfeCabecalho
    {
        public MdfeCabecalho()
        {
            InitializeComponent();
        }

        private MdfeCabecalhoModel Model => DataContext as MdfeCabecalhoModel;

        private void InicializaCabecalho(object sender, EventArgs e)
        {
            CbUfCarregamento.PickItem += ComboBoxUfCarregamento_OnPickItem;
            CbUfCarregamento.UfSelecionado = CbUfCarregamento.Default;

            CbUfDescarregamento.PickItem += ComboBoxUfDescarregamento_OnPickItem;
            CbUfDescarregamento.UfSelecionado = CbUfDescarregamento.Default;

            CbCidadeCarregamento.PickItemCidade += ComboBoxCidadeCarregamento_OnPickItem;
            CbCidadeCarregamento.PesquisaPorUf(CbUfCarregamento.Default);

            CbPercurso.PickItem += ComboBoxPercurso_OnPickItem;
            CbPercurso.UfSelecionado = CbPercurso.Default;

            Model.Percurso.CollectionChanged += AtualizaComboCidade;
        }

        private void AtualizaComboCidade(object sender, NotifyCollectionChangedEventArgs e)
        {
            PesquisarCidadesPorUf();
        }

        private void ComboBoxPercurso_OnPickItem(object sender, RoutedEventArgs e)
        {
            var comboBoxUf = e.Source as ComboBoxUf;
            Model.PercursoSelecionado = comboBoxUf?.UfSelecionado;
        }

        private void ComboBoxCidadeCarregamento_OnPickItem(object sender, RoutedEventArgs e)
        {
            var comboBoxCidade = e.Source as ComboBoxCidade;
            Model.MunicipioCarregamentoSelecionado = comboBoxCidade?.CidadeSelecionado;
        }

        private void ComboBoxUfDescarregamento_OnPickItem(object sender, RoutedEventArgs e)
        {
            var comboBoxUf = e.Source as ComboBoxUf;
            Model.UfDescarregamento = comboBoxUf?.UfSelecionado;
            PesquisarCidadesPorUf();
        }

        private void PesquisarCidadesPorUf()
        {
            var filtroList = new List<Uf>();

            if (CbUfCarregamento.UfSelecionado != null)
            {
                filtroList.Add(CbUfCarregamento.UfSelecionado);
            }

            if (CbUfDescarregamento.UfSelecionado != null)
            {
                filtroList.Add(CbUfDescarregamento.UfSelecionado);
            }

            filtroList.AddRange(Model.Percurso);

            CbCidadeCarregamento.PesquisaPorUf(filtroList.ToArray());
        }

        private void ComboBoxUfCarregamento_OnPickItem(object sender, RoutedEventArgs e)
        {
            var comboBoxUf = e.Source as ComboBoxUf;
            Model.UfCarregamento = comboBoxUf?.UfSelecionado;
            PesquisarCidadesPorUf();
        }

        private void TrocouUfCarregamentoAction(object sender, EventArgs e)
        {
            CbUfCarregamento.UfSelecionado = Model.UfCarregamento;
        }

        private void TrocouUfDescarregamentoAction(object sender, EventArgs e)
        {
            CbUfDescarregamento.UfSelecionado = Model.UfDescarregamento;
        }

        private void This_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Model.LoadedCabecalho += InicializaCabecalho;
            Model.TrocouUfCarregamentoHandler += TrocouUfCarregamentoAction;
            Model.TrocouUfDescarregamentoHandler += TrocouUfDescarregamentoAction;
        }
    }
}
