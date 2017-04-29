using System;
using System.Windows.Input;
using GThorFrameworkWpf.Models.Base;

namespace GThorGeraMigracao
{
    public class GeraVersaoWindowModel : ModelViewBase
    {
        private long _nomeArquivoMigracao;

        public long NomeArquivoMigracao
        {
            get => _nomeArquivoMigracao;
            set
            {
                if (value == _nomeArquivoMigracao) return;
                _nomeArquivoMigracao = value;
                OnPropertyChanged();
            }
        }

        public ICommand GerarVersaoMigracao => GetSimpleCommand(GeraVersaoMigracaoAction);

        private void GeraVersaoMigracaoAction(object obj)
        {
            NomeArquivoMigracao = DateTime.Now.ToFileTime();
        }
    }
}