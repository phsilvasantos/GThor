using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GThorFrameworkDominio.Dominios.Cidades;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkDominio.Dominios.Pessoas.Flags;

namespace GThorFrameworkDominio.Dominios.Pessoas
{
    [Table("pessoa")]
    public class Pessoa
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("tipoPessoa")]
        [Required]
        public TipoPessoa TipoPessoa { get; set; } = TipoPessoa.Fisica;

        [Column("nome")]
        [MaxLength(255)]
        [Required]
        public string Nome { get; set; }

        [Column("nomeFantasia")]
        [MaxLength(255)]
        [Required]
        public string NomeFantasia { get; set; }

        [Column("cnpj")]
        [MaxLength(14)]
        [Required]
        public string Cnpj { get; set; }

        [Column("cpf")]
        [MaxLength(11)]
        [Required]
        public string Cpf { get; set; }

        [Column("InscricaoEstadual")]
        [MaxLength(30)]
        [Required]
        public string InscricaoEstadual { get; set; }

        [Column("ufId")]
        [Required]
        public int UfId { get; set; }
        public Uf Uf { get; set; }

        [Column("cidadeId")]
        [Required]
        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }

        [Column("telefone")]
        [MaxLength(11)]
        [Required]
        public string Telefone { get; set; }

        [Column("email")]
        [MaxLength(255)]
        [Required]
        public string Email { get; set; }

        public virtual Transportadora Transportadora { get; set; } = new Transportadora();

        public virtual Condutor Condutor { get; set; } = new Condutor();
    }
}