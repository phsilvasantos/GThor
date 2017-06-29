using System.ComponentModel;
using GThorFrameworkWpf.Helpers.Conversores;

namespace GThorFrameworkDominio.Dominios.MdfeFiscal.Flags
{
    [TypeConverter(typeof(EnumTypeDescriptionConverter))]
    public enum ResponsavelSeguro
    {
        [Description("1 - Emitente do MDF-e")]
        Emitente = 1,

        [Description("2 - Responsável pela Contratação (Contratante)")]
        ResponsavelContratacao = 2
    }
}