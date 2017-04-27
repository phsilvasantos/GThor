using System.ComponentModel.DataAnnotations.Schema;

namespace GThorFrameworkDominio.Dominios.EstadosUf
{
    [Table("uf")]
    public class Uf
    {
        public int Id { get; set; }

        public string Sigla { get; set; }

        public string Nome { get; set; }

        public byte CodigoIbge { get; set; }
    }
}