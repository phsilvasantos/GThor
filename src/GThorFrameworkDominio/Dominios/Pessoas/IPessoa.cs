using GThorFrameworkDominio.Dominios.Cidades;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkDominio.Dominios.Pessoas.Flags;

namespace GThorFrameworkDominio.Dominios.Pessoas
{
    public interface IPessoa
    {
        int Id { get; }
        TipoPessoa TipoPessoa { get; set; }
        string Nome { get; set; }
        string NomeFantasia { get; set; }
        string Cnpj { get; set; }
        string Cpf { get; set; }
        string InscricaoEstadual { get; set; }
        Uf Uf { get; set; }
        Cidade Cidade { get; set; }
        string Telefone { get; set; }
        string Email { get; set; }
    }
}