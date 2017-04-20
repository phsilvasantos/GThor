
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GThorFrameworkDominio.Dominios.Usuarios
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("login")]
        [MaxLength(20)]
        [Required]
        public string Login { get; set; }

        [Column("senha")]
        [MaxLength(40)]
        [Required]
        public string Senha { get; set; }
    }
}