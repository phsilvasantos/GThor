using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GThorFrameworkDominio.Dominios.Pessoas
{
    [Table("condutor")]
    public class Condutor
    {
        [Key]
        [Column("pessoaId")]
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}