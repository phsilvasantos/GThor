using System.Collections.Generic;
using System.Linq;
using GThorFrameworkDominio.Dominios.Certificados;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Implementacao.Base;

namespace GThorRepositorioEntityFramework.Implementacao
{
    internal class RepositorioCertificadoDigital : RepositorioBase, IRepositorioCertificadoDigital
    {
        public CertificadoDigital CarregarPorId(int id)
        {
            return GThorContexto.CertificadosDigitais.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<CertificadoDigital> Lista()
        {
            return GThorContexto.CertificadosDigitais.ToList();
        }

        public void SalvarOuAtualizar(CertificadoDigital entity)
        {
            if (entity.Id == 0)
            {
                GThorContexto.CertificadosDigitais.Add(entity);
                return;
            }

            GThorContexto.CertificadosDigitais.Update(entity);
        }

        public void Deletar(CertificadoDigital entity)
        {
            GThorContexto.CertificadosDigitais.Remove(entity);
        }
    }
}