
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
        public virtual int Id { get; set; }

        [Column("login")]
        [MaxLength(20)]
        [Required]
        public virtual string Login { get; set; }

        [Column("senha")]
        [MaxLength(40)]
        [Required]
        public virtual string Senha { get; set; }
    }
}