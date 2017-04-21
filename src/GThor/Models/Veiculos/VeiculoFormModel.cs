using System;
using GThorFrameworkWpf.Models.Base;
using GThorNegocio.Dto;

namespace GThor.Models.Veiculos
{
    public class VeiculoFormModel : ModelViewBase
    {
        private UfComboBoxDto _ufDtoSelecionado;

        public UfComboBoxDto UfDtoSelecionado
        {
            get { return _ufDtoSelecionado; }
            set
            {
                _ufDtoSelecionado = value;
                OnPropertyChanged();
            }
        }

        protected override void LoadedCommandAction(object obj)
        {
            Salvar += SalvarConcluido;
        }

        private void SalvarConcluido(object sender, EventArgs e)
        {
            var uf = UfDtoSelecionado;

        }
    }
}