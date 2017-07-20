using GThorFrameworkWpf.Models.Base;

namespace GThor.Models.MdfeFiscal.Base
{
    public class MdfeViewModel : ModelViewBase
    {
        private bool _habilitado;
        private bool _selecionado;

        public bool Habilitado
        {
            get => _habilitado;
            set
            {
                if (value == _habilitado) return;
                _habilitado = value;
                OnPropertyChanged();
            }
        }

        public bool Selecionado
        {
            get => _selecionado;
            set
            {
                if (value == _selecionado) return;
                _selecionado = value;
                OnPropertyChanged();
            }
        }
    }
}