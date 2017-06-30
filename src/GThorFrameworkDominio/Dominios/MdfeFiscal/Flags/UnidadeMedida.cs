using System.ComponentModel;
using GThorFrameworkWpf.Helpers.Conversores;

namespace GThorFrameworkDominio.Dominios.MdfeFiscal.Flags
{
    [TypeConverter(typeof(EnumTypeDescriptionConverter))]
    public enum UnidadeMedida
    {
        [Description("1 - Quilograma")]
        Kg = 1,

        [Description("2 - Tonelada")]
        Ton = 2
    }
}