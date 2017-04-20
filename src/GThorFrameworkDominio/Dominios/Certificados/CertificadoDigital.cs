using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GThorFrameworkDominio.Dominios.Certificados
{
    [Table("certificadoDigital")]
    public class CertificadoDigital
    {
        public CertificadoDigital()
        {
            Tipo = TipoCertificado.A1Arquivo;
        }

        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("caminhoCertificado")]
        public string CaminhoCertificado { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("serial")]
        public string Serial { get; set; }

        [Required]
        public TipoCertificado Tipo { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("senha")]
        public string Senha { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("descricao")]
        public string Descricao { get; set; }
    }
}