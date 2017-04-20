using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GThorFrameworkDominio.Dominios.EstadosUf
{
    [Table("uf")]
    public class Uf
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("sigla")]
        [Required]
        [MaxLength(2)]
        public string Sigla { get; set; }

        [Column("nome")]
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Column("codigoIbge")]
        [Required]
        public byte CodigoIbge { get; set; }
    }
}