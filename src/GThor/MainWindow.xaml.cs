using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using GThor.Models;
using GThor.Models.CertificadoDigitais;
using GThor.Models.DocumentosMdfe;
using GThor.Models.Empresas;
using GThor.Models.Pessoas;
using GThor.Models.Usuarios;
using GThor.Models.Veiculos;
using GThorFrameworkWpf.Views.DataGrid;
using GThorNegocio.Criadores;
using GThorNegocio.Negocios;
using GThorRepositorioEntityFramework.Implementacao;
using MahApps.Metro.Controls;

namespace GThor
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            DataContext = new MainWindowModel();
            InitializeComponent();
        }

        private void GerenciarUsuarios_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var negocio = NegocioCriador.CriaNegocioUsuario();

            AbrirTabItem("Usuarios", DataGridPadrao.Criar(new GridUsuarioModel(negocio)));
        }

        private void CertificadoDigitais_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var negocio = NegocioCriador.CriaNegocioCertificadoDigital();

            AbrirTabItem("Certificados", DataGridPadrao.Criar(new GridCertificadoDigitalModel(negocio)));
        }

        private void DocumentoMdfe_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var negocio = NegocioCriador.CriaNegocioDocumentoMdfe();

            AbrirTabItem("Documentos MDF-e", DataGridPadrao.Criar(new GridDocumentoMdfeModel(negocio)));
        }

        private void Veiculo_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var negocio = NegocioCriador.CriaNegocioVeiculo();

            AbrirTabItem("Veículos", DataGridPadrao.Criar(new GridVeiculoModel(negocio)));
        }

        private void GerenciarEmpresa_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            AbrirTabItem("Empresas", DataGridPadrao.Criar(new GridEmpresaModel(NegocioCriador.CriaNegocioEmpresa())));
        }

        private void GerenciarPessoa_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            AbrirTabItem("Pessoas", DataGridPadrao.Criar(new GridPessoaModel(NegocioCriador.CriaNegocioPessoa())));
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
