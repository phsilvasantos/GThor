using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos.flags;

namespace GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos
{
    [Table("documentoMdfe")]
    public class DocumentoMdfe
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("ambienteSefaz")]
        public AmbienteSefaz AmbienteSefaz { get; set; }

        [Required]
        [Column("serie")]
        public short Serie { get; set; }

        [Required]
        [Column("ultimoNumeroUsado")]
        public long UltimoNumeroUsado { get; set; }
    }
}