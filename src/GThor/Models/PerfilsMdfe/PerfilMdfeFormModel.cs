using System;
using GThorFrameworkBiblioteca.Ferramentas.HelpersHidratacaoValores;
using GThorFrameworkDominio.Dominios.Certificados;
using GThorFrameworkDominio.Dominios.Empresas;
using GThorFrameworkDominio.Dominios.MdfeFiscal.Perfils;
using GThorFrameworkDominio.Dto.CertificadosDigitais;
using GThorFrameworkDominio.Dto.Empresas;
using GThorFrameworkWpf.Models.Base;
using GThorNegocio.Contratos;
using GThorNegocio.Criadores;

namespace GThor.Models.PerfilsMdfe
{
    public class PerfilMdfeFormModel : ModelViewBase
    {
        private readonly INegocioPerfilMdfe _negocioPerfilMdfe;
        private string _descricao;

        public PerfilMdfe PerfilMdfe { get; set; }

        public string Descricao
        {
            get => _descricao; set
            {
                if (value == _descricao) return;
                _descricao = value;
                OnPropertyChanged();
            }
        }

        public EmpresaComboBoxDto EmpresaComboBoxDto { get; set; }
        public CertificadoDigitalComboBoxDto CertificadoDigitalComboBoxDto { get; set; }

        public PerfilMdfeFormModel(INegocioPerfilMdfe negocioPerfilMdfe)
        {
            _negocioPerfilMdfe = negocioPerfilMdfe;
        }

        protected override void Loaded()
        {
            ValidaAntesSalvar += ValidarInformacoes;
            Salvar += SalvarConclui;
        }

        private void SalvarConclui(object sender, EventArgs e)
        {
            PerfilMdfe.Descricao = Descricao;
            PerfilMdfe.CertificadoDigital = new CertificadoDigital {Id = CertificadoDigitalComboBoxDto.Id};
            PerfilMdfe.Empresa = new Empresa {Id = EmpresaComboBoxDto.Id};

            _negocioPerfilMdfe.SalvarOuAtualizar(PerfilMdfe);
        }

        private void ValidarInformacoes(object sender, EventArgs e)
        {
            Descricao = Descricao.TrimOrEmptyIsNotNull("Hmm, seu perfil não tem descrição. So pode cadastrar se tiver");

            if (EmpresaComboBoxDto == null) throw new ArgumentException("Hmm, seu perfil não tem empresa. So pode cadastrar se tiver");

            if (CertificadoDigitalComboBoxDto == null) throw new ArgumentException("Hmm, seu perfil não tem certificado digital. So pode cadastrar se tiver");
        }
    }
}