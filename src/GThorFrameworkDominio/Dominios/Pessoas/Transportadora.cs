using GThorFrameworkDominio.Dominios.Pessoas.Flags;

namespace GThorFrameworkDominio.Dominios.Pessoas
{
    public class Transportadora : Pessoa
    {
        public string Rntrc { get; set; }
        public TipoProprietario TipoProprietario { get; set; }
    }
}