using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using GThorFrameworkWpf.Models.Base;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace GThorFrameworkWpf.Models.DataGrid
{
    public abstract class DataGridPadraoModel<TEntidade> : ModelViewBase, IDataGridModel
    {

        public DataGridPadraoModel()
        {
            BotaoFiltroVisivel = true;
            BotaoNovoVisivel = true;
            DescricaoPesquisa = "Pesquisa rapida";
            ColunasDataGrid = new ObservableCollection<DataGridColumn>();
            ListaEntidades = new ObservableCollection<TEntidade>();
            AdicionaColunasNaLista();
        }

        private bool _isOpenPopupFiltro;
        private UserControl _popupFiltro;
        private string _descricaoPesquisa;
        private string _pesquisarTexto;
        private bool _botaoFiltroVisivel;
        private bool _botaoNovoVisivel;
        private bool _botaoDeletar = true;
        private bool _botaoEditar = true;
        private bool _botaoOpcoes;
        private TEntidade _entidadeSelecionada;
        public ICommand CommandFiltro => GetSimpleCommand(FiltrarAction);

        public ICommand CommandNovoRegistro => GetSimpleCommand(NovoRegistroAction);

        public ICommand CommandAplicarFiltro => GetSimpleCommand(AplicarFiltroAction);

        public ICommand CommandButtonEditar => GetSimpleCommand(EditarRegistroAction);

        public ICommand CommandButtonOpcoes => GetSimpleCommand(OpcoesAction);

        public ICommand CommandButtonDeletar => GetSimpleCommand(async obje =>
        {
            await DeletarRegistroAction();
        });

        public bool BotaoDeletar
        {
            get { return _botaoDeletar; }
            set
            {
                if (value == _botaoDeletar) return;
                _botaoDeletar = value;
                OnPropertyChanged();
            }
        }

        public bool BotaoEditar
        {
            get { return _botaoEditar; }
            set
            {
                if (value == _botaoEditar) return;
                _botaoEditar = value;
                OnPropertyChanged();
            }
        }

        public bool BotaoOpcoes
        {
            get { return _botaoOpcoes; }
            set
            {
                if (value == _botaoOpcoes) return;
                _botaoOpcoes = value;
                OnPropertyChanged();
            }
        }

        private async Task<MessageDialogResult> DeletarRegistroAction()
        {
            var window = BuscarJanelaAtiva();

            if (window != null)
            {
                var retorno = await window.ShowMessageAsync("Deletar Registro", "Deseja deletar o registro?",
                    MessageDialogStyle.AffirmativeAndNegative);

                if (retorno == MessageDialogResult.Negative)
                    return retorno;
            }

            DeletarRegistroSelecionado();

            IniciaPesquisa(PesquisarTexto);

            return MessageDialogResult.Affirmative;
        }

        private MetroWindow BuscarJanelaAtiva()
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive) as MetroWindow;
            return window;
        }

        protected virtual void DeletarRegistroSelecionado()
        {
            
        }

        protected virtual void OpcoesAction(object obj)
        {
            
        }

        protected virtual void EditarRegistroAction(object obj)
        {
            DuploClickDataGrid();
        }


        public bool BotaoFiltroVisivel
        {
            get { return _botaoFiltroVisivel; }
            set
            {
                if (value == _botaoFiltroVisivel) return;
                _botaoFiltroVisivel = value;
                OnPropertyChanged();
            }
        }

        public bool BotaoNovoVisivel
        {
            get { return _botaoNovoVisivel; }
            set
            {
                if (value == _botaoNovoVisivel) return;
                _botaoNovoVisivel = value;
                OnPropertyChanged();
            }
        }

        public virtual void AplicarFiltroAction(object obj)
        {
            if (IniciaPesquisa(PesquisarTexto))
            {
                AplicaPesquisa(PesquisarTexto);
            }
        }

        public virtual void NovoRegistroAction(object obj)
        {
            
        }

        private void AdicionaColunasNaLista()
        {
            CriarColunas();
        }

        public ObservableCollection<DataGridColumn> ColunasDataGrid { get; set; }

        // ReSharper disable once CollectionNeverQueried.Global
        public ObservableCollection<TEntidade> ListaEntidades { get; }

        protected IEnumerable<TEntidade> Cache { get; set; }

        public string DescricaoPesquisa
        {
            get { return _descricaoPesquisa; }
            set
            {
                if (value == _descricaoPesquisa) return;
                _descricaoPesquisa = value;
                OnPropertyChanged();
            }
        }

        public string PesquisarTexto
        {
            get { return _pesquisarTexto; }
            set
            {
                if (value == _pesquisarTexto) return;
                _pesquisarTexto = value;
                OnPropertyChanged();
            }
        }

        private void FiltrarAction(object obj)
        {
            IsOpenPopupFiltro = true;
        }

        public bool IsOpenPopupFiltro
        {
            get { return _isOpenPopupFiltro; }
            set
            {
                if (value == _isOpenPopupFiltro) return;
                _isOpenPopupFiltro = value;
                OnPropertyChanged();
            }
        }

        public UserControl PopupFiltro
        {
            get { return _popupFiltro; }
            set
            {
                if (Equals(value, _popupFiltro)) return;
                _popupFiltro = value;
                OnPropertyChanged();
            }
        }

        public TEntidade EntidadeSelecionada
        {
            get { return _entidadeSelecionada; }
            set
            {
                if (Equals(value, _entidadeSelecionada)) return;
                _entidadeSelecionada = value;
                OnPropertyChanged();
            }
        }


        public void AdicionarDataGridColumn(string cabecalho, string bindingPath, DataGridLength larguraColuna)
        {
            AdicionarDataGridColumn(cabecalho, new Binding(bindingPath), larguraColuna);
        }

        public void AdicionarDataGridColumn(string cabecalho, string bindingPath)
        {
            AdicionarDataGridColumn(cabecalho, new Binding(bindingPath));
        }

        public void AdicionarDataGridColumn(string cabecalho, Binding binding, DataGridLength larguraColuna)
        {
            var dataGridColumn = new DataGridTextColumn
            {
                Header = cabecalho,
                Binding = binding,
                Width = larguraColuna
            };

            ColunasDataGrid.Add(dataGridColumn);
        }

        public void AdicionarDataGridColumn(string cabecalho, Binding binding)
        {
            AdicionarDataGridColumn(cabecalho, binding, DataGridLength.Auto);
        }

        public void AdicionarDataGridColumn<TPropriedade>(Expression<Func<TPropriedade>> propriedade)
        {
            AdicionarDataGridColumn(propriedade, DataGridLength.Auto);
        }

        public void AdicionarDataGridColumn<TPropriedade>(Expression<Func<TPropriedade>> propriedade, DataGridLength larguraColuna)
        {
            AdicionarDataGridColumn(propriedade, propriedade, larguraColuna);
        }

        public void AdicionarDataGridColumn<TCabecalho, TBindingPath>(Expression<Func<TCabecalho>> cabecalho, Expression<Func<TBindingPath>> binding)
        {
            AdicionarDataGridColumn(cabecalho, binding, DataGridLength.Auto);
        }

        public void AdicionarDataGridColumn<TCabecalho, TBindingPath>(Expression<Func<TCabecalho>> cabecalho, Expression<Func<TBindingPath>> binding, DataGridLength larguraColuna)
        {
            var meCabecalho = (MemberExpression) cabecalho.Body;
            var meBindingPath = (MemberExpression) binding.Body;

            var cabecalhoTexto =
                string.Concat(meCabecalho.Member.Name.Select(c => char.IsUpper(c) ? " " + c.ToString() : c.ToString()))
                    .TrimStart();

            var bindingTexto = 
                meBindingPath.Member.Name;

            AdicionarDataGridColumn(cabecalhoTexto, bindingTexto, larguraColuna);
        }

        public abstract void BuscarRegistros();

        public bool IniciaPesquisa(string pesquisarTexto)
        {
            ListaEntidades.Clear();

            if (!string.IsNullOrEmpty(pesquisarTexto)) return true;

            BuscarRegistros();

            return false;
        }

        public abstract void AplicaPesquisa(string pesquisarTexto);

        public abstract void CriarColunas();

        public virtual void DuploClickDataGrid()
        {
            
        }

        public bool NaoTemRegistros()
        {
            return ListaEntidades.Count == 0;
        }

        public void PreencherLista(IEnumerable<TEntidade> lista)
        {
            foreach (var entidade in lista)
            {
                ListaEntidades.Add(entidade);
            }
        }
    }
}