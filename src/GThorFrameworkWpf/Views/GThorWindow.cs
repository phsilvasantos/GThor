using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls;

namespace GThorFrameworkWpf.Views
{
    public class GThorWindow : MetroWindow
    {
        public static readonly DependencyProperty LoadedCommandProperty
        = DependencyProperty.RegisterAttached(
             "LoadedCommand",
             typeof(ICommand),
             typeof(GThorWindow),
             new PropertyMetadata(null, OnLoadedCommandChanged));

        private static void OnLoadedCommandChanged
             (DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            var frameworkElement = depObj as FrameworkElement;
            if (frameworkElement != null && e.NewValue is ICommand)
            {
                frameworkElement.Loaded
                  += (o, args) =>
                    {
                        var command = e.NewValue as ICommand;

                        command?.Execute(null);
                    };
            }
        }

        public static ICommand GetLoadedCommand(DependencyObject depObj)
        {
            return (ICommand)depObj.GetValue(LoadedCommandProperty);
        }

        public static void SetLoadedCommand(
            DependencyObject depObj,
            ICommand value)
        {
            depObj.SetValue(LoadedCommandProperty, value);
        }

        public bool EUmRegistroNovo { get; set; }
    }
}