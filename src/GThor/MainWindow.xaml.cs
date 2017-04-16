using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using GThor.Models.Usuarios;
using GThorFrameworkWpf.Views.DataGrid;
using GThorNegocio.Negocios;
using GThorRepositorioEntityFramework.Implementacao;
using MahApps.Metro.Controls;

namespace GThor
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GerenciarUsuarios_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var negocio = new UsuarioNegocio(new RepositorioUsuario());

            AbrirTabItem("Usuarios", DataGridPadrao.Criar(new GridUsuarioModel(negocio)));
        }

        private void AbrirTabItem(string titulo, UserControl janela)
        {
            var novaTab = new MetroTabItem { Header = titulo, Content = janela, CloseButtonEnabled = true };

            foreach (var tabItem in TabControl.Items.Cast<TabItem>().Where(tabItem => tabItem.Header == novaTab.Header))
            {
                tabItem.Focus();
                return;
            }

            TabControl.Items.Add(novaTab);
            novaTab.Focus();
        }
    }
}
