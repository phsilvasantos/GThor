using System.ComponentModel;
using GThorFrameworkWpf.Helpers.Conversores;

namespace GThorFrameworkDominio.Dominios.Pessoas.Flags
{
    [TypeConverter(typeof(EnumTypeDescriptionConverter))]
    public enum TipoProprietario
    {
        [Description("TAC-Agregrado")]
        Agregado,
        [Description("TAC Independente")]
        Independente,
        Outros
    }
}