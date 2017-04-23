using System;
using System.Windows;
using GThor.Models.Empresas;
using GThorFrameworkComponentes.ComboBox;
using GThorFrameworkDominio.Dominios.Cidades;
using GThorFrameworkDominio.Dominios.EstadosUf;

namespace GThor.Views.Empresas
{
    public partial class EmpresaForm
    {
        public EmpresaForm(EmpresaFormModel model)
        {
            DataContext = model;
            InitializeComponent();
        }

        private void ComboBoxUfCidade_OnPickItemComboUfCidade(object sender, RoutedEventArgs e)
        {
            var comboBoxUfCidade = e.Source as ComboBoxUfCidade;

            var uf = comboBoxUfCidade?.UfSelecionado;
            var cidade = comboBoxUfCidade?.CidadeSelecionada;

            Console.WriteLine(uf?.Nome);
            Console.WriteLine(cidade?.Nome);
        }
    }
}
