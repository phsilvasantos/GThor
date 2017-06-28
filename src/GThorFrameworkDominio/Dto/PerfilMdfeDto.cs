using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos.flags;

namespace GThorFrameworkDominio.Dto
{
    public class PerfilMdfeDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public AmbienteSefaz AmbienteSefaz { get; set; }
        public long UltimoNumeroEmitido { get; set; }
    }
}