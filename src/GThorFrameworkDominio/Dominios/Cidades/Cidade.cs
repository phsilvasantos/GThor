using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GThorFrameworkDominio.Dominios.EstadosUf;

namespace GThorFrameworkDominio.Dominios.Cidades
{
    [Table("cidade")]
    public class Cidade
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("nome")]
        public string Nome { get; set; }

        [Required]
        [Column("codigoIbge")]
        public int CodigoIbge { get; set; }

        [Required]
        [Column("ufId")]
        public Uf Uf { get; set; }
    }
}