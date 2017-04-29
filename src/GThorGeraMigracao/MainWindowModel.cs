using System;
using GThorFrameworkBiblioteca.Ferramentas.HelpersHidratacaoValores;
using GThorFrameworkWpf.Models.Base;

namespace GThorGeraMigracao
{
    public class MainWindowModel : ModelViewBase
    {
        public string NomeArquivoMigracao { get; set; }

        protected override void Loaded()
        {
            ValidaAntesSalvar += Valdiar;
            Salvar += SalvarAction;
        }

        private void SalvarAction(object sender, EventArgs e)
        {
            
        }

        private void Valdiar(object sender, EventArgs e)
        {
            if (NomeArquivoMigracao.IsNullOrEmpty()) throw new ArgumentException("Nome da migração não pode ser vazio");

            if (NomeArquivoMigracao.Contains(" ")) throw new ArgumentException("Nome da migração não pode conter espaços, exemplo de nome\nCriaTabelaUsuario, CriaTabelaCidade, InsereEstadosUf, InsereCidades");
        }
    }
}