using System;
using GThorFrameworkWpf.Models.Base;
using GThorNegocio.Criadores;

namespace GThor.Models
{
    public class MainWindowModel : ModelViewBase
    {
        public event EventHandler InicializaStartHandler;

        protected override void LoadedCommandAction(object obj)
        {
            var negocioMigracao = NegocioCriador.CriaNegocioMigracaoBancoDados();
            negocioMigracao.Migrar();
            OnInicializaStartHandler();
        }

        protected virtual void OnInicializaStartHandler()
        {
            InicializaStartHandler?.Invoke(this, EventArgs.Empty);
        }
    }
}