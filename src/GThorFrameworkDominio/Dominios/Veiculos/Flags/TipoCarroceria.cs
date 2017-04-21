using System.ComponentModel;
using GThorFrameworkWpf.Helpers.Conversores;

namespace GThorFrameworkDominio.Dominios.Veiculos.Flags
{
    [TypeConverter(typeof(EnumTypeDescriptionConverter))]
    public enum TipoCarroceria
    {
        [Description("Não Aplicável")]
        NaoAplicavel = 00,
        Aberta = 01,

        [Description("Fechada/Baú")]
        FechadaBau = 02,
        Graneleira = 03,

        [Description("Porta Container")]
        PortaContainer = 04,
        Sider = 05
    }
}