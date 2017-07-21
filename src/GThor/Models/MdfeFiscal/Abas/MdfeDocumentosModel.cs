using System;
using System.Windows.Input;
using GThor.Models.MdfeFiscal.Base;

namespace GThor.Models.MdfeFiscal.Abas
{
    public class MdfeDocumentosModel : MdfeViewModel
    {
        public event EventHandler VoltarMdfeCabecalho;

        public ICommand VoltarMdfeCabecalhoCommand => GetSimpleCommand(VoltarMdfeCabecalhoAction);

        private void VoltarMdfeCabecalhoAction(object obj)
        {
            OnVoltarMdfeCabecalho();
        }

        private void OnVoltarMdfeCabecalho()
        {
            VoltarMdfeCabecalho?.Invoke(this, EventArgs.Empty);
        }
    }
}