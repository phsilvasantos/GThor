﻿using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos;
using GThorNegocio.Contratos;
using GThorRepositorio.Contratos;
using GThorRepositorioNHibernate.Helpers;
using GThorRepositorioNHibernate.Helpers.Ext;

namespace GThorNegocio.Negocios
{
    internal class NegocioDocumentoMdfe : INegocioDocumentoMdfe
    {
        private readonly IRepositorioDocumentoMdfe _repositorioDocumentoMdfe;

        public NegocioDocumentoMdfe(IRepositorioDocumentoMdfe repositorioDocumentoMdfe)
        {
            _repositorioDocumentoMdfe = repositorioDocumentoMdfe;
        }


        public void SalvarOuAtualizar(DocumentoMdfe documentoMdfe)
        {
            using (var instancia = NHibernateHelper.InstanciaComTransacao())
            {
                _repositorioDocumentoMdfe.SetSession(instancia);
                _repositorioDocumentoMdfe.SalvarOuAtualizar(documentoMdfe);
            }
        }

        public DocumentoMdfe CarregarPorId(int id)
        {
            using (var instancia = NHibernateHelper.Instancia())
            {
                _repositorioDocumentoMdfe.SetSession(instancia);
                return _repositorioDocumentoMdfe.CarregarPorId(id);
            }
        }

        public IEnumerable<DocumentoMdfe> Lista()
        {
            using (var instancia = NHibernateHelper.Instancia())
            {
                _repositorioDocumentoMdfe.SetSession(instancia);

                return _repositorioDocumentoMdfe.Lista();
            }
        }

        public void Deletar(DocumentoMdfe documentoMdfe)
        {
            using (var instancia = NHibernateHelper.InstanciaComTransacao())
            {
                _repositorioDocumentoMdfe.SetSession(instancia);
                _repositorioDocumentoMdfe.Deletar(documentoMdfe);
            }
        }
    }
}