using System.ComponentModel;
using GThorFrameworkWpf.Helpers.Conversores;

namespace GThorFrameworkDominio.Dominios.MdfeFiscal.Flags
{
    [TypeConverter(typeof(EnumTypeDescriptionConverter))]
    public enum Modal
    {
        [Description("1 - Rodoviário")]
        Rodoviario = 1
    }
}