using System;
using System.Windows;
using GThor.Models.PerfilsMdfe;
using GThorFrameworkComponentes.ComboBox.CertificadosDigitais;
using GThorFrameworkComponentes.ComboBox.DocumentosDfe;
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

            ComboBoxEmpresa.EmpresaSelecionada = ComboBoxEmpresa.Padrao;
            ComboBoxCertificadoDigital.CertificadoDigitalSelecionado = ComboBoxCertificadoDigital.Padrao;
            ComboBoxDocumentoMdfe.DocumentoMdfeSelecionado = ComboBoxDocumentoMdfe.Padrao;
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

        private void ComboBoxDocumentoMdfe_OnPickItemDocumentoMdfe(object sender, RoutedEventArgs e)
        {
            var comboBoxDocumentoMdfe = e.Source as ComboBoxDocumentoMdfe;

            var documentoMdfeComboBoxDto = comboBoxDocumentoMdfe?.DocumentoMdfeSelecionado;

            _model.DocumentoMdfeComboBoxDto = documentoMdfeComboBoxDto;
        }

        private void PerfilMdfeForm_OnContentRendered(object sender, EventArgs e)
        {
            if (_model.PerfilMdfe.Id == 0) return;

            ComboBoxEmpresa.EmpresaSelecionada = _model.EmpresaComboBoxDto;
            ComboBoxCertificadoDigital.CertificadoDigitalSelecionado = _model.CertificadoDigitalComboBoxDto;
            ComboBoxDocumentoMdfe.DocumentoMdfeSelecionado = _model.DocumentoMdfeComboBoxDto;
        }
    }
}
