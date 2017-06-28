using System.Windows;
using GThorFrameworkComponentes.ComboBox.Empresas;

namespace GThor.Views.PerfilsMdfe
{
    public partial class PerfilMdfeForm
    {
        public PerfilMdfeForm()
        {
            InitializeComponent();
        }

        private void ComboBoxEmpresa_OnPickItemEmpresa(object sender, RoutedEventArgs e)
        {
            var comboBoxEmpresa = e.Source as ComboBoxEmpresa;

            var empresaComboBox = comboBoxEmpresa?.EmpresaSelecionada;

            //_model.EmpresaComboBox = empresaComboBox;
        }

        private void ComboBoxCertificadoDigital_OnPickItemCertificadoDigital(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
