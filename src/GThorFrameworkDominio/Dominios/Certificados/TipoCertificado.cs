using System.ComponentModel;
using GThorFrameworkWpf.Helpers.Conversores;

namespace GThorFrameworkDominio.Dominios.Certificados
{
    [TypeConverter(typeof(EnumTypeDescriptionConverter))]
    public enum TipoCertificado
    {
        [Description("A1 Arquivo")]
        A1Arquivo = 1,
        [Description("A1 Repositório")]
        A1Repositorio = 2,
        [Description("A3")]
        A3 = 3
    }
}