using System;
using System.Windows;
using System.Windows.Controls;
using ComercialFrameworkWpf.Views.DataGrid;
using ComercialFrameworkWpf.Views.DataGrid.Corpo;
using ComercialFrameworkWpf.Views.DataGrid.Filtro;
using GThorFrameworkWpf.Models.DataGrid;
using GThorFrameworkWpf.Views.DataGrid.Cabecalho;

namespace GThorFrameworkWpf.Views.DataGrid
{
    public partial class DataGridPadrao
    {
        private UserControl _cabecalho;
        private UserControl _corpo;
        private readonly IDataGridModel _model;
        private UserControl _popupFiltro;

        private DataGridPadrao(IDataGridModel model)
        {
            _model = model;
            InitializeComponent();
            InicializaComponentes();
        }

        private DataGridPadrao(IDataGridModel model, CabecalhoGridModel cabecalhoGridModel, CorpoGridModel corpo, PopupFiltro popupFiltro) : this(model)
        {
            _cabecalho = cabecalhoGridModel?.Cabecalho;
            _corpo = corpo?.Cropo;
            _popupFiltro = popupFiltro?.Filtro;
        }

        private void DataGridPadrao_OnLoaded(object sender, RoutedEventArgs e)
        {
            _model.BuscarRegistros();
        }

        private void InicializaComponentes()
        {
            AddCorpoECabecalhoPadrao();
            ConstruirEstruturaDataGridPadao();
        }

        private void ConstruirEstruturaDataGridPadao()
        {
            if (_cabecalho != null)
                DocPanelCabecalho.Children.Add(_cabecalho);

            if (_corpo != null)
                DockPanelCorpo.Children.Add(_corpo);

            if (_popupFiltro != null)
                _model.PopupFiltro = _popupFiltro;

            if (_model != null)
                DataContext = _model;
        }

        private void AddCorpoECabecalhoPadrao()
        {
            if (_cabecalho == null)
                _cabecalho = new CabecalhoPadrao();

            if (_corpo == null)
                _corpo = new CorpoPadrao();

            if (_popupFiltro == null)
                _popupFiltro = new PopupExFiltroPadrao();

            if (_model == null)
                throw new InvalidOperationException("Nunca pode passar o model null");
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static DataGridPadrao Criar(IDataGridModel model, CabecalhoGridModel cabecalhoGridModel, CorpoGridModel corpo, PopupFiltro popupFiltro)
        {
            var dataGridPadrao = new DataGridPadrao(model, cabecalhoGridModel, corpo, popupFiltro);

            return dataGridPadrao;
        }

        public static DataGridPadrao Criar(IDataGridModel model, CabecalhoGridModel cabecalhoGridModel, CorpoGridModel corpo)
        {
            // ReSharper disable once IntroduceOptionalParameters.Global
            return Criar(model, cabecalhoGridModel, corpo, null);
        }

        public static DataGridPadrao Criar(IDataGridModel model, CabecalhoGridModel cabecalhoGridModel)
        {
            // ReSharper disable once IntroduceOptionalParameters.Global
            return Criar(model, cabecalhoGridModel, null, null);
        }

        public static DataGridPadrao Criar(IDataGridModel model)
        {
            // ReSharper disable once IntroduceOptionalParameters.Global
            return Criar(model, null, null, null);
        }
    }
}
