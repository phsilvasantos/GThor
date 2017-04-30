using GThorFrameworkDominio.Base;
using GThorFrameworkDominio.Dominios.Cidades;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkDominio.Dominios.Pessoas.Flags;

namespace GThorFrameworkDominio.Dominios.Pessoas
{
    public class Transportadora : EntidadeDominio, IPessoa
    {
        private readonly int _pessoaId;

        protected Transportadora()
        {
            
        }

        public Transportadora(Pessoa pessoa, int id) 
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Pessoa = pessoa;
            _pessoaId = id;
            // ReSharper disable once VirtualMemberCallInConstructor
            TipoPessoa = TipoPessoa.Fisica;
            // ReSharper disable once VirtualMemberCallInConstructor
            TipoProprietario = TipoProprietario.Agregado;
        }

        // ReSharper disable once MemberCanBeProtected.Global
        public virtual Pessoa Pessoa { get; protected internal set; }

        // ReSharper disable once ConvertToAutoProperty
        public virtual int Id => _pessoaId;

        public virtual TipoPessoa TipoPessoa
        {
            get => Pessoa.TipoPessoa;
            set => Pessoa.TipoPessoa = value;
        }

        public virtual string Nome
        {
            get => Pessoa.Nome;
            set => Pessoa.Nome = value;
        }

        public virtual string NomeFantasia
        {
            get => Pessoa.NomeFantasia;
            set => Pessoa.NomeFantasia = value;
        }

        public virtual string Cnpj
        {
            get => Pessoa.Cnpj;
            set => Pessoa.Cnpj = value;
        }

        public virtual string Cpf
        {
            get => Pessoa.Cpf;
            set => Pessoa.Cpf = value;
        }

        public virtual string InscricaoEstadual
        {
            get => Pessoa.InscricaoEstadual;
            set => Pessoa.InscricaoEstadual = value;
        }

        public virtual Uf Uf
        {
            get => Pessoa.Uf;
            set => Pessoa.Uf = value;
        }

        public virtual Cidade Cidade
        {
            get => Pessoa.Cidade;
            set => Pessoa.Cidade = value;
        }

        public virtual string Telefone
        {
            get => Pessoa.Telefone;
            set => Pessoa.Telefone = value;
        }

        public virtual string Email
        {
            get => Pessoa.Email;
            set => Pessoa.Email = value;
        }

        public virtual string Rntrc { get; set; }

        public virtual TipoProprietario TipoProprietario { get; set; }

        protected override int IdUnico => _pessoaId;
    }
}