using System.Linq;
using GThor.Views;
using GThorFrameworkDominio.Dominios.Usuarios;
using GThorFrameworkWpf.Models.DataGrid;
using GThorNegocio.Contratos;

namespace GThor.Models.Usuarios
{
    public class GridUsuarioModel : DataGridPadraoModel<Usuario>
    {
        private readonly IUsuarioNegocio _usuarioNegocio;

        public GridUsuarioModel(IUsuarioNegocio usuarioNegocio)
        {
            _usuarioNegocio = usuarioNegocio;
        }

        public override void BuscarRegistros()
        {
            Cache = _usuarioNegocio.Lista();
            PreencherLista(Cache);
        }

        public override void AplicaPesquisa(string pesquisarTexto)
        {
            var listaFiltrada = Cache.Where(x => x.Login.Contains(pesquisarTexto)
                                                 || x.Id.ToString() == pesquisarTexto).ToList();

            PreencherLista(listaFiltrada);
        }

        public override void CriarColunas()
        {
            Usuario usuario = null;
            AdicionarDataGridColumn(() => usuario.Id, 40);
            AdicionarDataGridColumn(() => usuario.Login);
        }

        protected override void DeletarRegistroSelecionado()
        {
            _usuarioNegocio.Deletar(EntidadeSelecionada);
        }

        public override void NovoRegistroAction(object obj)
        {
            var model = new UsuarioFormModel();
            var usuarioForm = new UsuarioForm(model);

            usuarioForm.ShowDialog();
        }
    }
}