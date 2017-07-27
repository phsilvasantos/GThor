using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using DFe.Utils;
using GThorFrameworkBiblioteca.Ferramentas.HelpersHidratacaoValores;
using GThorFrameworkWpf.Models.Command;
using JetBrains.Annotations;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace GThorFrameworkWpf.Models.Base
{
    public abstract class ModelViewBase : INotifyPropertyChanged
    {
        private readonly IDictionary<string, RelayCommand> _flyweightCommand = new Dictionary<string, RelayCommand>();
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected ICommand GetSimpleCommand(
            Action<object> action,
            bool canExecute = true,
            [CallerMemberName] string chaveComando = null)
        {
            if (_flyweightCommand.ContainsKey(chaveComando))
                return _flyweightCommand[chaveComando];

            return _flyweightCommand[chaveComando] = new RelayCommand
            {
                ExecuteDelegate = action,
                CanExecuteDelegate = p => canExecute
            };
        }

        public EventHandler AtualizarListaHandler;
        protected EventHandler ValidaAntesSalvar;
        protected EventHandler Salvar;
        protected EventHandler PostSalvar;
        private bool _mostrarBotaoFechar = true;
        private bool _mostrarBotaoSalvar = true;
        protected bool FecharTelaAposSalvar = true;

        protected void OnAtualizarListaHandler()
        {
            AtualizarListaHandler?.Invoke(this, new EventArgs());
        }

        public bool MostrarBotaoFechar
        {
            get { return _mostrarBotaoFechar; }
            set
            {
                if (value == _mostrarBotaoFechar) return;
                _mostrarBotaoFechar = value;
                OnPropertyChanged();
            }
        }

        public bool MostrarBotaoSalvar
        {
            get { return _mostrarBotaoSalvar; }
            set
            {
                if (value == _mostrarBotaoSalvar) return;
                _mostrarBotaoSalvar = value;
                OnPropertyChanged();
            }
        }

        public ICommand SalvarCommand => GetSimpleCommand(SalvarAction);
        public ICommand FecharCommand => GetSimpleCommand(FecharAction);

        public ICommand LoadedCommand => GetSimpleCommand(LoadedCommandAction);

        public void LoadedCommandAction(object obj)
        {
            Loaded();

            DeixaTipoStringVazia();
        }

        protected virtual void Loaded()
        {
            
        }

        private void DeixaTipoStringVazia()
        {
            foreach (var propertyInfo in GetType().GetProperties())
            {
                if (propertyInfo.PropertyType != typeof(string)) continue;

                var valor = propertyInfo.GetValue(this, null) as string;

                if (valor.IsNullOrEmpty()) 
                   propertyInfo.SetValue(this, string.Empty);
            }
        }

        private void SalvarAction(object obj)
        {
            OnValidaAntesSalvar();
            OnSalvar();
            OnAtualizarListaHandler();
            OnPostSalvar();
        }

        private void OnPostSalvar()
        {
            PostSalvar?.Invoke(this, EventArgs.Empty);

            if (FecharTelaAposSalvar)
                FecharAction(this);
        }

        private void OnSalvar()
        {
            Salvar?.Invoke(this, EventArgs.Empty);
        }

        private void OnValidaAntesSalvar()
        {
            ValidaAntesSalvar?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void FecharAction(object obj)
        {
            var window = ObtemWindowAtual();
            window?.Close();
        }

        protected async void ShowDialogMessageAsync(string mensagem, string titulo = "GThor")
        {
            await ObtemWindowAtual().ShowMessageAsync(titulo, mensagem);
        }

        private static MetroWindow ObtemWindowAtual()
        {
            return Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive) as MetroWindow;
        }
    }
}