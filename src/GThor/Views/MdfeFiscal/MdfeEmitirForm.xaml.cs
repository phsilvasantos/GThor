using GThor.Models.MdfeFiscal;

namespace GThor.Views.MdfeFiscal
{
    public partial class MdfeEmitirForm
    {
        public MdfeEmitirForm()
        {
            DataContext = new MdfeEmitirFormModel();
            InitializeComponent();
        }
    }
}
