using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GThorFrameworkDominio.Dominios.Pessoas
{
    [Table("condutor")]
    public class Condutor
    {
        [Key, ForeignKey("Pessoa")]
        [Column("pessoaId")]
        public int PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}