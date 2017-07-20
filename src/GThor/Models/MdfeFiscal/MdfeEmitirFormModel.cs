using GThor.Models.MdfeFiscal.Abas;
using GThorFrameworkWpf.Models.Base;

namespace GThor.Models.MdfeFiscal
{
    public class MdfeEmitirFormModel : ModelViewBase
    {
        private MdfeCabecalhoModel _mdfeCabecalhoModel;

        public MdfeCabecalhoModel MdfeCabecalhoModel
        {
            get => _mdfeCabecalhoModel;
            set
            {
                if (Equals(value, _mdfeCabecalhoModel)) return;
                _mdfeCabecalhoModel = value;
                OnPropertyChanged();
            }
        }


        protected override void Loaded()
        {
            InicalizarComponentes();
        }

        private void InicalizarComponentes()
        {
            MdfeCabecalhoModel = new MdfeCabecalhoModel();
            MdfeCabecalhoModel.LoadedCommand.Execute(null);
        }
    }
}