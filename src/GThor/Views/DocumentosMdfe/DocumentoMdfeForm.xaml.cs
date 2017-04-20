using GThor.Models.DocumentosMdfe;

namespace GThor.Views.DocumentosMdfe
{
    public partial class DocumentoMdfeForm
    {
        public DocumentoMdfeForm(DocumentoMdfeFormModel model)
        {
            DataContext = model;
            InitializeComponent();
        }
    }
}
