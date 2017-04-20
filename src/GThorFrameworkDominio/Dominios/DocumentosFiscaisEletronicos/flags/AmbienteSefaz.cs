using System.ComponentModel;
using GThorFrameworkWpf.Helpers.Conversores;

namespace GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos.flags
{
    [TypeConverter(typeof(EnumTypeDescriptionConverter))]
    public enum AmbienteSefaz
    {
        [Description("Produção")]
        Producao = 1,

        [Description("Homologação")]
        Homologacao = 2
    }
}