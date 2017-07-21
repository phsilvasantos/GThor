using System;
using GThor.Models.MdfeFiscal.Abas;
using GThorFrameworkWpf.Models.Base;

namespace GThor.Models.MdfeFiscal
{
    public class MdfeEmitirFormModel : ModelViewBase
    {
        private MdfeCabecalhoModel _mdfeCabecalhoModel;
        private MdfeDocumentosModel _mdfeDocumentosModel;

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

        public MdfeDocumentosModel MdfeDocumentosModel
        {
            get => _mdfeDocumentosModel;
            set
            {
                if (Equals(value, _mdfeDocumentosModel)) return;
                _mdfeDocumentosModel = value;
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
            MdfeCabecalhoModel.ProximoMdfeDocumento += ProximoMdfeDocumento;

            MdfeDocumentosModel = new MdfeDocumentosModel();
            MdfeDocumentosModel.LoadedCommand.Execute(null);
            MdfeDocumentosModel.VoltarMdfeCabecalho += VoltarMdfeCabecalho;
        }

        private void VoltarMdfeCabecalho(object sender, EventArgs e)
        {
            MdfeCabecalhoModel.Habilitado = true;
            MdfeCabecalhoModel.Selecionado = true;
        }

        private void ProximoMdfeDocumento(object sender, MdfeCabecalhoModel e)
        {
            MdfeDocumentosModel.Habilitado = true;
            MdfeDocumentosModel.Selecionado = true;
        }
    }
}