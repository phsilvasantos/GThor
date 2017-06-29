using System.ComponentModel;
using GThorFrameworkWpf.Helpers.Conversores;

namespace GThorFrameworkDominio.Dominios.MdfeFiscal.Flags
{
    [TypeConverter(typeof(EnumTypeDescriptionConverter))]
    public enum TipoEmitente
    {
        [Description("1 - Prestador de serviço de transporte")]
        Transportadora = 1,

        [Description("2 - Transportador de Carga Própria")]
        Propria = 2
    }
}