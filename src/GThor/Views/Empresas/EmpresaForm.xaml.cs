using GThor.Models.Empresas;

namespace GThor.Views.Empresas
{
    public partial class EmpresaForm
    {
        public EmpresaForm(EmpresaFormModel model)
        {
            DataContext = model;
            InitializeComponent();
        }
    }
}
