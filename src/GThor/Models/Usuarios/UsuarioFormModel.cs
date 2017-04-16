using System;
using GThorFrameworkWpf.Models.Base;

namespace GThor.Models.Usuarios
{
    public class UsuarioFormModel : ModelViewBase
    {
        protected override void LoadedCommandAction(object obj)
        {
            ValidaAntesSalvar += ValidarAntesDeSalvar;
        }

        private string _login;
        private string _senha;

        public string Login
        {
            get => _login;
            set
            {
                if (value == _login) return;
                _login = value;
                OnPropertyChanged();
            }
        }

        public string Senha
        {
            get => _senha;
            set
            {
                if (value == _senha) return;
                _senha = value;
                OnPropertyChanged();
            }
        }


        private void ValidarAntesDeSalvar(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Login)) throw new InvalidOperationException("Nao e permitido salvar");
        }

    }
}