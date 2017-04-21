using System;
using GThorRepositorioEntityFramework.Contexto;
using GThorRepositorioEntityFramework.Contratos;

namespace GThorRepositorioEntityFramework.Implementacao.Base
{
    public class RepositorioBase : IRepositorioBase, IDisposable
    {
        public GThorContexto GThorContexto { get; set; }

        protected RepositorioBase()
        {
        }

        public void SalvarAlteracoes()
        {
            GThorContexto.SaveChanges();
        }

        public void Dispose()
        {
            GThorContexto?.Dispose();
        }
    }
}