using System;
using GThorRepositorioEntityFramework.Contexto.Contratos;
using GThorRepositorioEntityFramework.Contratos;

namespace GThorRepositorioEntityFramework.Implementacao.Base
{
    public class RepositorioBase : IRepositorioBase, IDisposable
    {
        public IGThorContexto GThorContexto { get; set; }

        protected RepositorioBase()
        {
        }

        public void SalvarAlteracoes()
        {
            GThorContexto.SaveChangesThor();
        }

        public void Dispose()
        {
            GThorContexto?.Dispose();
        }
    }
}