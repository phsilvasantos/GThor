using GThor.Models.CertificadoDigitais;

namespace GThor.Views
{
    public partial class CertificadoDigitalForm
    {
        public CertificadoDigitalForm(CertificadoDigitalFormModel model)
        {
            DataContext = model;
            InitializeComponent();
        }
    }
}
