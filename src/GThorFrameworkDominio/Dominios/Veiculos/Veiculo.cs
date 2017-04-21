using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkDominio.Dominios.Veiculos.Flags;

namespace GThorFrameworkDominio.Dominios.Veiculos
{
    [Table("veiculo")]
    public class Veiculo
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("descricao")]
        public string Descricao { get; set; }

        [MaxLength(10)]
        [Column("codigoInterno")]
        public string CodigoInterno { get; set; }

        [Required]
        [MaxLength(7)]
        [Column("placa")]
        public string Placa { get; set; }

        [Required]
        [MaxLength(11)]
        [Column("renavam")]
        public string Renavam { get; set; }

        [Required]
        [Column("taraEmKg")]
        public int TaraEmKg { get; set; }

        [Required]
        [Column("capacidadeEmKg")]
        public int CapacidadeEmKg { get; set; }

        [Required]
        [Column("tipoRodado")]
        public TipoRodado TipoRodado { get; set; }

        [Required]
        [Column("tipoCarroceria")]
        public TipoCarroceria TipoCarroceria { get; set; }

        [Required]
        [Column("ufId")]
        public int UfId { get; set; }

        public Uf Uf { get; set; }
    }
}