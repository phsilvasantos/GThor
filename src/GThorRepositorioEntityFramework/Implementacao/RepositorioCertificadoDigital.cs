using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Certificados;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Implementacao.Base;

namespace GThorRepositorioEntityFramework.Implementacao
{
    public class RepositorioCertificadoDigital : RepositorioBase, IRepositorioCertificadoDigital
    {
        public CertificadoDigital CarregarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CertificadoDigital> Lista()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void SalvarOuAtualizar(CertificadoDigital entity)
        {
            GThorContexto.CertificadoDigital.Add(entity);
        }

        public void Deletar(CertificadoDigital entity)
        {
            throw new System.NotImplementedException();
        }
    }
}