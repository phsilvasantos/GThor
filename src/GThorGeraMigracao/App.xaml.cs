using System;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace GThorGeraMigracao
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DispatcherUnhandledException += (sender, args) =>
            {
                UnhandledExcpetionHandler(args);
            };
        }

        private void UnhandledExcpetionHandler(DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;

            Current.Dispatcher.Invoke(async () =>
            {
                var window = Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive) as MetroWindow;

                if (window != null)
                {
                    var exception = e.Exception;

                    if (typeof(ArgumentException) == exception.GetType())
                    {
                        await window.ShowMessageAsync("Validação Inválida", e.Exception.Message);
                        return;
                    }

                    if (typeof(InvalidOperationException) == exception.GetType())
                    {
                        await window.ShowMessageAsync("Operação Inválida", e.Exception.Message);
                        return;
                    }


                    await window.ShowMessageAsync("Operação Inválida", e.Exception.Message);
                }
            });
        }
    }
}
