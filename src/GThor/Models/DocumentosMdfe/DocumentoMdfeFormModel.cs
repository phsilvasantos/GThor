using System;
using GThorFrameworkBiblioteca.Ferramentas.HelpersHidratacaoValores;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos.flags;
using GThorFrameworkWpf.Models.Base;
using GThorNegocio.Contratos;

namespace GThor.Models.DocumentosMdfe
{
    public class DocumentoMdfeFormModel : ModelViewBase
    {
        private readonly INegocioDocumentoMdfe _negocioDocumentoMdfe;

        public DocumentoMdfeFormModel(INegocioDocumentoMdfe negocioDocumentoMdfe)
        {
            _negocioDocumentoMdfe = negocioDocumentoMdfe;
        }

        private AmbienteSefaz _ambienteSefaz = AmbienteSefaz.Producao;
        private string _descricao;
        private short _serie;
        private long _ultimoNumeroUsado;

        public DocumentoMdfe DocumentoMdfe { get; set; }

        public AmbienteSefaz AmbienteSefaz
        {
            get => _ambienteSefaz;
            set
            {
                if (value == _ambienteSefaz) return;
                _ambienteSefaz = value;
                OnPropertyChanged();
            }
        }

        public string Descricao
        {
            get => _descricao;
            set
            {
                if (value == _descricao) return;
                _descricao = value;
                OnPropertyChanged();
            }
        }

        public short Serie
        {
            get => _serie;
            set
            {
                if (value == _serie) return;
                _serie = value;
                OnPropertyChanged();
            }
        }

        public long UltimoNumeroUsado
        {
            get => _ultimoNumeroUsado;
            set
            {
                if (value == _ultimoNumeroUsado) return;
                _ultimoNumeroUsado = value;
                OnPropertyChanged();
            }
        }

        protected override void Loaded()
        {
            ValidaAntesSalvar += Validacoes;
            Salvar += SalvarAction;

            if (DocumentoMdfe.Id != 0)
            {
                Descricao = DocumentoMdfe.Descricao;
                AmbienteSefaz = DocumentoMdfe.AmbienteSefaz;
                Serie = DocumentoMdfe.Serie;
                UltimoNumeroUsado = DocumentoMdfe.UltimoNumeroUsado;
            }
        }

        private void SalvarAction(object sender, EventArgs e)
        {
            DocumentoMdfe.Descricao = Descricao;
            DocumentoMdfe.AmbienteSefaz = AmbienteSefaz;
            DocumentoMdfe.Serie = Serie;
            DocumentoMdfe.UltimoNumeroUsado = UltimoNumeroUsado;

            _negocioDocumentoMdfe.SalvarOuAtualizar(DocumentoMdfe);
        }

        private void Validacoes(object sender, EventArgs e)
        {
            Descricao = Descricao.TrimOrEmpty();

            if (Descricao.IsNullOrEmpty()) throw new ArgumentException("Nossa, você esqueceu da descrição :O");

            if (Serie == 0) throw new ArgumentException("Ahhh, não existe série 0");
        }
    }
}