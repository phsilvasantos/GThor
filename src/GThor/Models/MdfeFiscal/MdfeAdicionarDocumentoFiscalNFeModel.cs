using System;
using System.Collections.Generic;
using System.Windows.Input;
using DFe.Utils;
using GThor.Models.MdfeFiscal.EntidadesModels;
using GThorFrameworkBiblioteca.Ferramentas.HelpersHidratacaoValores;
using GThorFrameworkDominio.Dominios.Cidades;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkWpf.Models.Base;

namespace GThor.Models.MdfeFiscal
{
    public class MdfeAdicionarDocumentoFiscalNFeModel : ModelViewBase
    {
        public event EventHandler<IDocumentoModel> AdicionarDocumentoNFeHandler; 

        private string _chaveNFe;
        private string _codigoBarras;
        private Cidade _cidade;
        public IList<Uf> UfsPesquisa { get; set; }

        public string ChaveNFe
        {
            get => _chaveNFe;
            set
            {
                if (value == _chaveNFe) return;
                _chaveNFe = value;
                OnPropertyChanged();
            }
        }

        public string CodigoBarras
        {
            get => _codigoBarras;
            set
            {
                if (value == _codigoBarras) return;
                _codigoBarras = value;
                OnPropertyChanged();
            }
        }

        public Cidade Cidade
        {
            get => _cidade;
            set
            {
                if (Equals(value, _cidade)) return;
                _cidade = value;
                OnPropertyChanged();
            }
        }

        public ICommand AdicionarNfeCommand => GetSimpleCommand(AdicionarNfeAction);

        private void AdicionarNfeAction(object obj)
        {
            if (ChaveNFe.IsNullOrEmpty())
                throw new ArgumentException("Digite uma chave de nf-e heheh");

            if (ChaveNFe.Length != 44) 
                throw new ArgumentException("A chave somente é válida se tiver 44 dígitos");

            if (!ChaveFiscal.ChaveValida(ChaveNFe))
                throw new ArgumentException("Eita, chave inválida");

            if (Cidade == null)
                throw new ArgumentException("Selecione uma cidade de descarregamento");

            OnAdicionarDocumentoNFeHandler(new NFeEntidadeModel
            {
                Cidade = Cidade,
                Chave = ChaveNFe,
                CodigoBarras = CodigoBarras
            });
            
            ShowDialogMessageAsync("Documento NF-e adicionado com sucessoooo");

            LimpaCampos();
        }

        private void LimpaCampos()
        {
            Cidade = null;
            ChaveNFe = string.Empty;
            CodigoBarras = string.Empty;
        }

        protected virtual void OnAdicionarDocumentoNFeHandler(NFeEntidadeModel e)
        {
            AdicionarDocumentoNFeHandler?.Invoke(this, e);
        }
    }
}