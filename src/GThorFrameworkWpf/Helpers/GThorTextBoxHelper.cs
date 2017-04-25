using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using GThorFrameworkBiblioteca.Ferramentas.HelpersHidratacaoValores;

namespace GThorFrameworkWpf.Helpers
{
    public static class GThorTextBoxHelper
    {
        public static readonly DependencyProperty NumeroInteiroProperty =
            DependencyProperty.RegisterAttached("NumeroInteiro", typeof(bool), typeof(GThorTextBoxHelper),
                new FrameworkPropertyMetadata(false, NumeroInteiroChanged));

        public static readonly DependencyProperty TrimProperty =
            DependencyProperty.RegisterAttached("Trim", typeof(bool), typeof(GThorTextBoxHelper),
                new FrameworkPropertyMetadata(false, TrimChanged));

        private static void TrimChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as TextBoxBase;
            if (textBox == null)
                throw new InvalidOperationException("GThorTextBoxHelper deve ser utilizado apenas em TextBox");

            if ((bool) e.NewValue)
            {
                textBox.TextChanged += ChangedTextboxInputTrim;
                textBox.LostFocus += LostTextBoxTrim;
            }
            else
            {
                textBox.TextChanged -= ChangedTextboxInputTrim;
                textBox.LostFocus -= LostTextBoxTrim;
            }
        }

        private static void LostTextBoxTrim(object sender, RoutedEventArgs e)
        {
             var textBox = sender as TextBox;

            if (textBox == null) return;

            if (textBox.Text.IsNullOrEmpty())
            {
                textBox.Text = string.Empty;
            }

            textBox.Text = textBox.Text?.TrimOrEmpty();
        }

        private static void ChangedTextboxInputTrim(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox == null) return;

            textBox.Text = textBox.Text?.TrimStart();
        }

        private static void NumeroInteiroChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as TextBoxBase;
            if (textBox == null)
                throw new InvalidOperationException("GThorTextBoxHelper deve ser utilizado apenas em TextBox");

            if ((bool)e.NewValue) textBox.PreviewTextInput += PreviewTextboxInputNumeroInteiro;
            else textBox.PreviewTextInput -= PreviewTextboxInputNumeroInteiro;
        }

        private static void PreviewTextboxInputNumeroInteiro(object sender, TextCompositionEventArgs e)
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

        public static bool GetTrim(DependencyObject obj)
        {
            return (bool)obj.GetValue(TrimProperty);
        }

        public static void SetTrim(DependencyObject obj, bool value)
        {
            obj.SetValue(TrimProperty, value);
        }
    }
}