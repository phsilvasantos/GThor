using System.ComponentModel;
using GThorFrameworkWpf.Helpers.Conversores;

namespace GThorFrameworkDominio.Dominios.Pessoas.Flags
{
    [TypeConverter(typeof(EnumTypeDescriptionConverter))]
    public enum TipoPessoa
    {
        [Description("Jurídica")]
        Juridica,
        [Description("Física")]
        Fisica
    }
}