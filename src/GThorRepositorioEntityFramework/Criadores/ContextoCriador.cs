using GThorRepositorioEntityFramework.Contexto;
using Microsoft.EntityFrameworkCore;

namespace GThorRepositorioEntityFramework.Criadores
{
    public class ContextoCriador
    {
        public DbContext CriaContexto()
        {
            return new GThorContexto();
        }
    }
}