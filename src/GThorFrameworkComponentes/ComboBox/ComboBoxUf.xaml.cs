using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using GThorNegocio.Dto;
using GThorNegocio.Negocios;
using GThorRepositorioEntityFramework.Implementacao;
using JetBrains.Annotations;

namespace GThorFrameworkComponentes.ComboBox
{
    public partial class ComboBoxUf : INotifyPropertyChanged
    {
        public static readonly DependencyProperty EstadoUfSelecionadoProperty =
            DependencyProperty.Register("EstadoUfSelecionado", typeof(UfComboBoxDto), typeof(ComboBoxUf), new PropertyMetadata(default(UfComboBoxDto), PropertyChangedCallback));


        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as ComboBoxUf;

            if (control != null)
            {
                control.UfSelecionado = (UfComboBoxDto) e.NewValue;
            }
        }

        public UfComboBoxDto EstadoUfSelecionado
        {
            get => (UfComboBoxDto)GetValue(EstadoUfSelecionadoProperty);
            set => SetValue(EstadoUfSelecionadoProperty, value);
        }


        private ObservableCollection<UfComboBoxDto> _listaEstadoUf;
        private UfComboBoxDto _ufSelecionado;

        public UfComboBoxDto UfSelecionado
        {
            get => _ufSelecionado;
            set
            {
                if (Equals(value, _ufSelecionado)) return;
                _ufSelecionado = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<UfComboBoxDto> ListaEstadoUf
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
            UfSelecionado = ListaEstadoUf[0];
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
            ListaEstadoUf = new ObservableCollection<UfComboBoxDto>();

            var listaUf = new NegocioUf(new RepositorioUf()).ListaParaComboBox();

            foreach (var ufComboBoxDto in listaUf)
            {
                ListaEstadoUf.Add(ufComboBoxDto);
            }
        }
    }
}
