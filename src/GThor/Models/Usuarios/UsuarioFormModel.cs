using System;
using GThorFrameworkWpf.Models.Base;
using GThorFrameworkBiblioteca.Ferramentas.HelpersHidratacaoValores;
using GThorFrameworkDominio.Dominios.Usuarios;
using GThorNegocio.Contratos;

namespace GThor.Models.Usuarios
{
    public class UsuarioFormModel : ModelViewBase
    {
        private readonly INegocioUsuario _usuarioNegocio;
        public Usuario Usuario { get; set; }

        public UsuarioFormModel(INegocioUsuario usuarioNegocio)
        {
            _usuarioNegocio = usuarioNegocio;
        }

        protected override void Loaded()
        {
            ValidaAntesSalvar += ValidarAntesDeSalvar;
            Salvar += SalvarUsuario;

            if (Usuario.Id != 0)
            {
                Login = Usuario.Login;
            }
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


        private void SalvarUsuario(object sender, EventArgs e)
        {
            Usuario.Login = Login;
            Usuario.Senha = Senha.Sha1();
            _usuarioNegocio.SalvarOuAtualizar(Usuario);
        }

        private void ValidarAntesDeSalvar(object sender, EventArgs e)
        {
            Login = Login.TrimOrEmpty();
            Senha = Senha.TrimOrEmpty();

            if (Login.IsNullOrEmpty()) throw new ArgumentException("Hei, digite um login valido né");
            if (Login.IsContemEspacos()) throw new ArgumentException("Não vou deixar você cadastrar um Login contendo espaços viu");

            if (Senha.IsNullOrEmpty()) throw new ArgumentException("Hei, digite uma senha valida né");
            if (Senha.IsContemEspacos()) throw new ArgumentException("Não vou deixar você cadastrar uma senha contendo espaços viu");
        }

    }
}