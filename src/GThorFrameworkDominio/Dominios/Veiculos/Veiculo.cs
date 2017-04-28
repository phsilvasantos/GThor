using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkDominio.Dominios.Veiculos.Flags;

namespace GThorFrameworkDominio.Dominios.Veiculos
{
    public class Veiculo
    {
        public virtual int Id { get; set; }

        public virtual string Descricao { get; set; }

        public virtual string CodigoInterno { get; set; }

        public virtual string Placa { get; set; }

        public virtual string Renavam { get; set; }

        public virtual int TaraEmKg { get; set; }

        public virtual int CapacidadeEmKg { get; set; }

        public virtual short CapacidadeEmM3 { get; set; }

        public virtual TipoRodado TipoRodado { get; set; } = TipoRodado.Truck;

        public virtual TipoCarroceria TipoCarroceria { get; set; } = TipoCarroceria.NaoAplicavel;

        public virtual int UfId { get; set; }

        public virtual Uf Uf { get; set; }
    }
}