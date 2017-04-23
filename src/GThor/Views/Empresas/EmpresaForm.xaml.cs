using System.Windows;
using GThor.Models.Empresas;
using GThorFrameworkComponentes.ComboBox;

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
    }
}
