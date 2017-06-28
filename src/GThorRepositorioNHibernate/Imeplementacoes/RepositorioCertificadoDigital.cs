using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Certificados;
using GThorFrameworkDominio.Dto.CertificadosDigitais;
using GThorRepositorio.Contratos;
using GThorRepositorioNHibernate.Imeplementacoes.Base;
using NHibernate.Transform;

namespace GThorRepositorioNHibernate.Imeplementacoes
{
    internal class RepositorioCertificadoDigital : RepositorioBase, IRepositorioCertificadoDigital
    {
        public CertificadoDigital CarregarPorId(int id)
        {
            return Sessao.Get<CertificadoDigital>(id);
        }

        public IEnumerable<CertificadoDigital> Lista()
        {
            return Sessao.QueryOver<CertificadoDigital>().List<CertificadoDigital>();
        }

        public void SalvarOuAtualizar(CertificadoDigital entity)
        {
            Sessao.SaveOrUpdate(entity);
        }

        public void Deletar(CertificadoDigital entity)
        {
            Sessao.Delete(entity);
        }

        public IEnumerable<CertificadoDigitalComboBoxDto> BuscarParaComboBox()
        {
            CertificadoDigital certificadoDigital = null;
            CertificadoDigitalComboBoxDto resultado = null;

            var query = Sessao.QueryOver(() => certificadoDigital)
                .SelectList(list => list.Select(() => certificadoDigital.Id).WithAlias(() => resultado.Id)
                    .Select(() => certificadoDigital.Descricao).WithAlias(() => resultado.Descricao));

            query.TransformUsing(Transformers.AliasToBean<CertificadoDigitalComboBoxDto>());

            var lista = query.List<CertificadoDigitalComboBoxDto>();

            return lista;
        }
    }
}