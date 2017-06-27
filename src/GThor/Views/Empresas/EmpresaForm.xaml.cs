using System;
using System.Windows;
using GThor.Models.Empresas;
using GThorFrameworkComponentes.ComboBox;
using ComboBoxUfCidade = GThorFrameworkComponentes.ComboBox.EstadosUFs.ComboBoxUfCidade;

namespace GThor.Views.Empresas
{
    public partial class EmpresaForm
    {
        private readonly EmpresaFormModel _model;

        public EmpresaForm(EmpresaFormModel model)
        {
            _model = model;
            DataContext = _model;
            InitializeComponent();
        }

        private void ComboBoxUfCidade_OnPickItemComboUfCidade(object sender, RoutedEventArgs e)
        {
            var comboBoxUfCidade = e.Source as ComboBoxUfCidade;

            var uf = comboBoxUfCidade?.UfSelecionado;
            var cidade = comboBoxUfCidade?.CidadeSelecionada;

            _model.Uf = uf;
            _model.Cidade = cidade;
        }

        private void EmpresaForm_OnContentRendered(object sender, EventArgs e)
        {
            ContentLoaded();
        }

        private void ContentLoaded()
        {
            if (_model.Empresa.Id == 0) return;
            ComboBoxUfCidade.SetEstadoUf(_model.Empresa.Uf);
            ComboBoxUfCidade.SetCidade(_model.Empresa.Cidade);
        }
    }
}
