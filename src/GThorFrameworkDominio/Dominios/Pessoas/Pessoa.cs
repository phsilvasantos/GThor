using GThorFrameworkDominio.Base;
using GThorFrameworkDominio.Dominios.Cidades;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkDominio.Dominios.Pessoas.Flags;

namespace GThorFrameworkDominio.Dominios.Pessoas
{
    public class Pessoa : EntidadeDominio, IPessoa
    {
        public Pessoa()
        {
            TipoPessoa = TipoPessoa.Fisica;
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public virtual int Id { get; protected internal set; }

        public virtual TipoPessoa TipoPessoa { get; set; }
        
        public virtual string Nome { get; set; }

        public virtual string NomeFantasia { get; set; }

        public virtual string Cnpj { get; set; }

        public virtual string Cpf { get; set; }
        
        public virtual string InscricaoEstadual { get; set; }

        public virtual Uf Uf { get; set; }

        public virtual Cidade Cidade { get; set; }

        public virtual string Telefone { get; set; }

        public virtual string Email { get; set; }

        public virtual Transportadora Transportadora { get; set; }

        public virtual Condutor Condutor { get; set; }

        protected override int IdUnico => Id;
    }
}