using GThor.Models.Pessoas;

namespace GThor.Views.Pessoas
{
    public partial class PessoaForm
    {
        public PessoaForm(PessoaFormModel model)
        {
            DataContext = model;
            InitializeComponent();
        }
    }
}
