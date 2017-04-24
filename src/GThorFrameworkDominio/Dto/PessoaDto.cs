using GThorFrameworkBiblioteca.Ferramentas.HelpersHidratacaoValores;

namespace GThorFrameworkDominio.Dto
{
    public class PessoaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public string DocumentoUnico => GetDocumentoUnico();

        private string GetDocumentoUnico()
        {
            return Cpf.IsNullOrEmpty() ? Cnpj : Cpf;
        }
    }
}