using System;

namespace ComercialBiblioteca.Ferramentas.HelpersCriptografia
{
    public static class GuuidHelper
    {
        public static string CriarUnico()
        {
            return Criar(DateTime.Now.ToString("O"));
        }

        public static string Criar(string input)
        {
            var md5 = Md5Helper.CriarComByte(input);

            return new Guid(md5).ToString();
        }
    }
}