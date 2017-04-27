using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GThorFrameworkDominio.Dominios.Cidades;
using GThorFrameworkDominio.Dominios.EstadosUf;

namespace GThorFrameworkDominio.Dominios.Empresas
{
    public class Empresa
    {
        public int Id { get; set; }

        public string Cnpj { get; set; }

        public string InscricaoEstadual { get; set; }

        public string Rntrc { get; set; }

        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }

        public string Cep { get; set; }

        public int UfId { get; set; }
        public Uf Uf { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }
    }
}