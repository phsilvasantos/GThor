using GThor.Models.Veiculos;

namespace GThor.Views.Veiculos
{
    public partial class VeiculoForm
    {
        public VeiculoForm()
        {
            DataContext = new VeiculoFormModel();
            InitializeComponent();
        }
    }
}
