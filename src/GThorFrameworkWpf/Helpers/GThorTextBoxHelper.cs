using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace GThorFrameworkWpf.Helpers
{
    public static class GThorTextBoxHelper
    {
        public static readonly DependencyProperty NumeroInteiroProperty =
            DependencyProperty.RegisterAttached("NumeroInteiro", typeof(bool), typeof(GThorTextBoxHelper),
                new FrameworkPropertyMetadata(false, NumeroInteiroChanged));

        private static void NumeroInteiroChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as TextBoxBase;
            if (textBox == null)
                throw new InvalidOperationException("GThorTextBoxHelper deve ser utilizado apenas em TextBox");

            if ((bool)e.NewValue) textBox.PreviewTextInput += PreviewTextInputHanlder;
            else textBox.PreviewTextInput -= PreviewTextInputHanlder;
        }

        private static void PreviewTextInputHanlder(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        public static void SetNumeroInteiro(DependencyObject obj, bool value)
        {
            obj.SetValue(NumeroInteiroProperty, value);
        }

        public static bool GetNumeroInteiro(DependencyObject obj)
        {
            return (bool)obj.GetValue(NumeroInteiroProperty);
        }
    }
}