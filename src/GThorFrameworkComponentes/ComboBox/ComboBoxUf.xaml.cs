﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorNegocio.Criadores;
using JetBrains.Annotations;

namespace GThorFrameworkComponentes.ComboBox
{
    public partial class ComboBoxUf : INotifyPropertyChanged
    {
        private static readonly RoutedEvent PickItemEvent =
            EventManager.RegisterRoutedEvent("PickItem", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ComboBoxUf));

        public event RoutedEventHandler PickItem
        {
            add => AddHandler(PickItemEvent, value);
            remove => RemoveHandler(PickItemEvent, value);
        }

        private void OnChanceItem()
        {
            RaiseEvent(new RoutedEventArgs(PickItemEvent, this));
        }

        private ObservableCollection<Uf> _listaEstadoUf;
        private Uf _ufSelecionado;

        public Uf UfSelecionado
        {
            get => _ufSelecionado;
            set
            {
                if (Equals(value, _ufSelecionado)) return;
                _ufSelecionado = value;
                OnPropertyChanged();
                OnChanceItem();
            }
        }

        public ObservableCollection<Uf> ListaEstadoUf
        {
            get => _listaEstadoUf;
            set
            {
                if (Equals(value, _listaEstadoUf)) return;
                _listaEstadoUf = value;
                OnPropertyChanged();
            }
        }

        public ComboBoxUf()
        {
            DataContext = this;
            PreencherListaEstadoUf();
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void PreencherListaEstadoUf()
        {
            ListaEstadoUf = new ObservableCollection<Uf>();

            var listaUf = NegocioCriador.CriaNegocioUf().Lista();

            foreach (var ufComboBoxDto in listaUf)
            {
                ListaEstadoUf.Add(ufComboBoxDto);
            }
        }
    }
}