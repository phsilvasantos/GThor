using System.ComponentModel;
using GThorFrameworkWpf.Helpers.Conversores;

namespace GThorFrameworkDominio.Dominios.MdfeFiscal.Flags
{
    [TypeConverter(typeof(EnumTypeDescriptionConverter))]
    public enum TipoTransportador
    {
        [Description("1 - ETC")]
        Etc = 1,

        [Description("2 - TAC")]
        Tac = 2,

        [Description("3 - CTC")]
        Ctc = 3
    }
}