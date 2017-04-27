using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos.flags;

namespace GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos
{
    public class DocumentoMdfe
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public AmbienteSefaz AmbienteSefaz { get; set; } = AmbienteSefaz.Producao;

        public short Serie { get; set; }

        public long UltimoNumeroUsado { get; set; }
    }
}