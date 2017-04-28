using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Certificados;
using GThorRepositorio.Contratos;
using GThorRepositorioNHibernate.Imeplementacoes.Base;

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
    }
}