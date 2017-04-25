using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GThorFrameworkDominio.Dominios.Pessoas.Flags;

namespace GThorFrameworkDominio.Dominios.Pessoas
{
    [Table("transportadora")]
    public class Transportadora
    {
        [Key, ForeignKey("Pessoa")]
        [Column("pessoaId")]
        public int PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        [Column("rntrc")]
        [MaxLength(8)]
        [Required]
        public string Rntrc { get; set; }

        [Column("tipoProprietario")]
        [Required]
        public TipoProprietario TipoProprietario { get; set; }
    }
}