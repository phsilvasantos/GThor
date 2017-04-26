using System;
using System.Windows;
using GThor.Models.Pessoas;
using GThorFrameworkComponentes.ComboBox;

namespace GThor.Views.Pessoas
{
    public partial class PessoaForm
    {
        private readonly PessoaFormModel _model;

        public PessoaForm(PessoaFormModel model)
        {
            _model = model;
            DataContext = _model;
            InitializeComponent();

            
        }

        private void InicializaComboBox()
        {
            if (_model.Pessoa.Id == 0) return;

            ComboBoxUfCidade.SetEstadoUfId(_model.Pessoa.Id);
            ComboBoxUfCidade.SetCidadeId(_model.Pessoa.Id);
        }

        private void ComboBoxUfCidade_OnPickItemComboUfCidade(object sender, RoutedEventArgs e)
        {
            var comboBoxUfCidade = e.Source as ComboBoxUfCidade;

            _model.Uf = comboBoxUfCidade?.UfSelecionado;
            _model.Cidade = comboBoxUfCidade?.CidadeSelecionada;
        }

        private void PessoaForm_OnContentRendered(object sender, EventArgs e)
        {
            InicializaComboBox();
        }
    }
}
