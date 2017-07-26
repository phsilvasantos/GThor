using System;
using System.Collections.Generic;
using System.Windows.Input;
using GThor.Models.MdfeFiscal.Base;
using GThorFrameworkDominio.Dominios.EstadosUf;

namespace GThor.Models.MdfeFiscal.Abas
{
    public class MdfeDocumentosModel : MdfeViewModel
    {
        private bool _isNfe;
        private bool _isCte;
        public event EventHandler VoltarMdfeCabecalho;

        public ICommand VoltarMdfeCabecalhoCommand => GetSimpleCommand(VoltarMdfeCabecalhoAction);

        public bool IsNfe
        {
            get => _isNfe;
            set
            {
                if (value == _isNfe) return;
                _isNfe = value;
                OnPropertyChanged();
            }
        }

        public bool IsCte
        {
            get => _isCte;
            set
            {
                if (value == _isCte) return;
                _isCte = value;
                OnPropertyChanged();
            }
        }

        public IList<Uf> UfsPesquisa { get; set; }

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