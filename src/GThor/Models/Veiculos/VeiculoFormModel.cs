using System;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkWpf.Models.Base;

namespace GThor.Models.Veiculos
{
    public class VeiculoFormModel : ModelViewBase
    {
        private Uf _ufSelecionado;

        public Uf UfSelecionado
        {
            get => _ufSelecionado;
            set
            {
                _ufSelecionado = value;
                OnPropertyChanged();
            }
        }

        protected override void LoadedCommandAction(object obj)
        {
            Salvar += SalvarConcluido;
        }

        private void SalvarConcluido(object sender, EventArgs e)
        {
            var uf = UfSelecionado;

        }
    }
}