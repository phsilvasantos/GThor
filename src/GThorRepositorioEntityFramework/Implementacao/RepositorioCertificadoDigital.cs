using System.Collections.Generic;
using System.Linq;
using GThorFrameworkDominio.Dominios.Certificados;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Implementacao.Base;

namespace GThorRepositorioEntityFramework.Implementacao
{
    public class RepositorioCertificadoDigital : RepositorioBase, IRepositorioCertificadoDigital
    {
        public CertificadoDigital CarregarPorId(int id)
        {
            return GThorContexto.CertificadoDigital.Find(id);
        }

        public IEnumerable<CertificadoDigital> Lista()
        {
            return GThorContexto.CertificadoDigital.ToList();
        }

        public void Dispose()
        {
            GThorContexto.Dispose();
        }

        public void SalvarOuAtualizar(CertificadoDigital entity)
        {
            if (entity.Id == 0)
            {
                GThorContexto.CertificadoDigital.Add(entity);
                return;
            }

            GThorContexto.CertificadoDigital.Update(entity);
        }

        public void Deletar(CertificadoDigital entity)
        {
            GThorContexto.CertificadoDigital.Remove(entity);
        }
    }
}