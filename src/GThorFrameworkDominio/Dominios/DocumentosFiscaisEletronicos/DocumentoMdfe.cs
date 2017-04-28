using GThorFrameworkDominio.Base;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos.flags;

namespace GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos
{
    public class DocumentoMdfe : EntidadeDominio
    {
        public virtual int Id { get; set; }

        public virtual string Descricao { get; set; }

        public virtual AmbienteSefaz AmbienteSefaz { get; set; } = AmbienteSefaz.Producao;

        public virtual short Serie { get; set; }

        public virtual long UltimoNumeroUsado { get; set; }

        protected override int IdUnico => Id;
    }
}