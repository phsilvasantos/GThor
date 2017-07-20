using System;
using System.Collections.Generic;
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

        private void InicializaComboBox()
        {
            CbUfCarregamento.PickItem += ComboBoxUfCarregamento_OnPickItem;
            CbUfCarregamento.UfSelecionado = CbUfCarregamento.Default;

            CbUfDescarregamento.PickItem += ComboBoxUfDescarregamento_OnPickItem;
            CbUfDescarregamento.UfSelecionado = CbUfDescarregamento.Default;

            CbCidadeCarregamento.PickItemCidade += ComboBoxCidadeCarregamento_OnPickItem;
            CbCidadeCarregamento.PesquisaPorUf(CbUfCarregamento.Default);
        }

        private void ComboBoxCidadeCarregamento_OnPickItem(object sender, RoutedEventArgs e)
        {
            
        }

        private void ComboBoxUfDescarregamento_OnPickItem(object sender, RoutedEventArgs e)
        {
            var comboBoxUf = e.Source as ComboBoxUf;
            (DataContext as MdfeCabecalhoModel).UfDescarregamento = comboBoxUf?.UfSelecionado;
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

            CbCidadeCarregamento.PesquisaPorUf(filtroList.ToArray());
        }

        private void ComboBoxUfCarregamento_OnPickItem(object sender, RoutedEventArgs e)
        {
            var comboBoxUf = e.Source as ComboBoxUf;
            (DataContext as MdfeCabecalhoModel).UfCarregamento = comboBoxUf?.UfSelecionado;
            PesquisarCidadesPorUf();
        }

        private void MdfeCabecalho_OnLoaded(object sender, RoutedEventArgs e)
        {
            InicializaComboBox();
            (DataContext as MdfeCabecalhoModel).TrocouUfCarregamentoHandler += TrocouUfCarregamentoAction;
            (DataContext as MdfeCabecalhoModel).TrocouUfDescarregamentoHandler += TrocouUfDescarregamentoAction;
        }

        private void TrocouUfCarregamentoAction(object sender, EventArgs e)
        {
            CbUfCarregamento.UfSelecionado = (DataContext as MdfeCabecalhoModel)?.UfCarregamento;
        }

        private void TrocouUfDescarregamentoAction(object sender, EventArgs e)
        {
            CbUfDescarregamento.UfSelecionado = (DataContext as MdfeCabecalhoModel)?.UfDescarregamento;
        }
    }
}
