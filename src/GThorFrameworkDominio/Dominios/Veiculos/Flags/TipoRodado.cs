using System.ComponentModel;
using GThorFrameworkWpf.Helpers.Conversores;

namespace GThorFrameworkDominio.Dominios.Veiculos.Flags
{
    [TypeConverter(typeof(EnumTypeDescriptionConverter))]
    public enum TipoRodado
    {
        Truck = 01,
        Toco = 02,

        [Description("Cavalo Mecânico")]
        CavaloMecanico = 03,
        Van = 04,

        [Description("Utilitário")]
        Utilitario = 05,
        Outros = 06
    }
}