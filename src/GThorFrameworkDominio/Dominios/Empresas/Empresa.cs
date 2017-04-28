using GThorFrameworkDominio.Base;
using GThorFrameworkDominio.Dominios.Cidades;
using GThorFrameworkDominio.Dominios.EstadosUf;

namespace GThorFrameworkDominio.Dominios.Empresas
{
    public class Empresa : EntidadeDominio
    {
        public virtual int Id { get; set; }

        public virtual string Cnpj { get; set; }

        public virtual string InscricaoEstadual { get; set; }

        public virtual string Rntrc { get; set; }

        public virtual string RazaoSocial { get; set; }

        public virtual string NomeFantasia { get; set; }

        public virtual string Logradouro { get; set; }

        public virtual string Numero { get; set; }

        public virtual string Complemento { get; set; }

        public virtual string Bairro { get; set; }

        public virtual int CidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }

        public virtual string Cep { get; set; }

        public virtual int UfId { get; set; }
        public virtual Uf Uf { get; set; }

        public virtual string Telefone { get; set; }

        public virtual string Email { get; set; }

        protected override int IdUnico => Id;
    }
}