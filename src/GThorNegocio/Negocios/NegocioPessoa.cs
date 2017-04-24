﻿using System.Collections.Generic;
using GThorFrameworkDominio.Dto;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Criadores;
using GThorRepositorioEntityFramework.Extensoes;

namespace GThorNegocio.Negocios
{
    internal class NegocioPessoa : INegocioPessoa
    {
        private readonly IRepositorioPessoa _repositorioPessoa;

        public NegocioPessoa(IRepositorioPessoa repositorioPessoa)
        {
            _repositorioPessoa = repositorioPessoa;
        }

        public IEnumerable<PessoaDto> BuscarParaGridModel()
        {
            using (var contexto = ContextoCriador.CriaContexto())
            {
                _repositorioPessoa.SetGThorContexto(contexto);
                return _repositorioPessoa.BuscarParaGridModel();
            }
        }
    }
}