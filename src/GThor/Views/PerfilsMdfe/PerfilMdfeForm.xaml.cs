using System.Windows;
using GThor.Models.PerfilsMdfe;
using GThorFrameworkComponentes.ComboBox.CertificadosDigitais;
using GThorFrameworkComponentes.ComboBox.Empresas;

namespace GThor.Views.PerfilsMdfe
{
    public partial class PerfilMdfeForm
    {
        private readonly PerfilMdfeFormModel _model;

        public PerfilMdfeForm(PerfilMdfeFormModel model)
        {
            _model = model;
            DataContext = _model;
            InitializeComponent();

            ComboBoxEmpresa.EmpresaSelecionada = ComboBoxEmpresa.Default;
            ComboBoxCertificadoDigital.CertificadoDigitalSelecionado =
                ComboBoxCertificadoDigital.Default;
        }

        private void ComboBoxEmpresa_OnPickItemEmpresa(object sender, RoutedEventArgs e)
        {
            var comboBoxEmpresa = e.Source as ComboBoxEmpresa;

            var empresaComboBox = comboBoxEmpresa?.EmpresaSelecionada;

            _model.EmpresaComboBoxDto = empresaComboBox;
        }

        private void ComboBoxCertificadoDigital_OnPickItemCertificadoDigital(object sender, RoutedEventArgs e)
        {
            var comboBoxCertificadoDigital = e.Source as ComboBoxCertificadoDigital;

            var certificadoDigitalComboBoxDto = comboBoxCertificadoDigital?.CertificadoDigitalSelecionado;

            _model.CertificadoDigitalComboBoxDto = certificadoDigitalComboBoxDto;
        }
    }
}
