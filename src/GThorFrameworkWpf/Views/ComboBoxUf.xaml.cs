using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace GThorFrameworkWpf.Views
{
    public partial class ComboBoxUf : INotifyPropertyChanged
    {

        //public ObservableCollection<UfComboBoxDto> ListaEstadoUf { get; set; }

        public ComboBoxUf()
        {
            DataContext = this;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
