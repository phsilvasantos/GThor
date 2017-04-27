using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkDominio.Dominios.Veiculos.Flags;

namespace GThorFrameworkDominio.Dominios.Veiculos
{
    public class Veiculo
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public string CodigoInterno { get; set; }

        public string Placa { get; set; }

        public string Renavam { get; set; }

        public int TaraEmKg { get; set; }

        public int CapacidadeEmKg { get; set; }

        public short CapacidadeEmM3 { get; set; }

        public TipoRodado TipoRodado { get; set; } = TipoRodado.Truck;

        public TipoCarroceria TipoCarroceria { get; set; } = TipoCarroceria.NaoAplicavel;

        public int UfId { get; set; }

        public virtual Uf Uf { get; set; }
    }
}