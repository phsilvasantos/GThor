using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GThorFrameworkDominio.Dominios.Cidades;
using GThorFrameworkDominio.Dominios.EstadosUf;

namespace GThorFrameworkDominio.Dominios.Empresas
{
    [Table("empresa")]
    public class Empresa
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("cnpj")]
        [MaxLength(14)]
        [Required]
        public string Cnpj { get; set; }

        [Column("inscricaoEstadual")]
        [MaxLength(30)]
        [Required]
        public string InscricaoEstadual { get; set; }

        [Column("rntrc")]
        [MaxLength(8)]
        [Required]
        public string Rntrc { get; set; }

        [Column("razaoSocial")]
        [MaxLength(255)]
        [Required]
        public string RazaoSocial { get; set; }

        [Column("nomeFantasia")]
        [MaxLength(255)]
        [Required]
        public string NomeFantasia { get; set; }

        [Column("logradouro")]
        [MaxLength(255)]
        [Required]
        public string Logradouro { get; set; }

        [Column("numero")]
        [MaxLength(60)]
        [Required]
        public string Numero { get; set; }

        [Column("complemento")]
        [MaxLength(60)]
        [Required]
        public string Complemento { get; set; }

        [Column("bairro")]
        [MaxLength(60)]
        [Required]
        public string Bairro { get; set; }

        [Column("cidadeId")]
        [Required]
        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }

        [Column("cep")]
        [MaxLength(8)]
        [Required]
        public string Cep { get; set; }

        [Column("ufId")]
        [Required]
        public int UfId { get; set; }
        public Uf Uf { get; set; }

        [Column("telefone")]
        [MaxLength(11)]
        [Required]
        public string Telefone { get; set; }

        [Column("email")]
        [MaxLength(255)]
        [Required]
        public string Email { get; set; }
    }
}