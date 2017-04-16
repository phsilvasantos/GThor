using GThor.Models.Usuarios;

namespace GThor.Views
{
    public partial class UsuarioForm
    {
        public UsuarioForm(UsuarioFormModel model)
        {
            DataContext = model;
            InitializeComponent();
        }
    }
}
