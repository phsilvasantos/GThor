using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GThorFrameworkDominio.Dominios.Pessoas
{
    [Table("condutor")]
    public class Condutor
    {
        [Key]
        [ForeignKey("condutor__pessoa")]
        [Column("pessoaId")]
        public int PessoaId { get; set; }
    }
}