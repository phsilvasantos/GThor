using System;
using GThorFrameworkWpf.Models.Base;

namespace GThor.Models
{
    public class MainWindowModel : ModelViewBase
    {
        public event EventHandler InicializaStartHandler;

        protected override void LoadedCommandAction(object obj)
        {
            OnInicializaStartHandler();
        }

        protected virtual void OnInicializaStartHandler()
        {
            InicializaStartHandler?.Invoke(this, EventArgs.Empty);
        }
    }
}