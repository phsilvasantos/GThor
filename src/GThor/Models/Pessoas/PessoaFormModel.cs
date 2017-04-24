using GThorFrameworkDominio.Dominios.Pessoas;
using GThorFrameworkWpf.Models.Base;
using GThorNegocio.Contratos;

namespace GThor.Models.Pessoas
{
    public class PessoaFormModel : ModelViewBase
    {
        private readonly INegocioPessoa _negocioPessoa;

        public PessoaFormModel(INegocioPessoa negocioPessoa)
        {
            _negocioPessoa = negocioPessoa;
        }

        public Pessoa Pessoa { get; set; }
    }
}