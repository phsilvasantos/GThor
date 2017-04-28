using System;
using System.Security.Cryptography;
using System.Text;

namespace GThorFrameworkBiblioteca.Ferramentas.HelpersCriptografia
{
    public static class Md5Helper
    {
        public static string CriaUnica()
        {
            return Criar(DateTime.Now.ToString("O"));
        }

        public static string Criar(string input)
        {
            using (var md5Hash = MD5.Create())
            {
                var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sBuilder = new StringBuilder();
                foreach (var t in data)
                {
                    sBuilder.Append(t.ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }

        public static byte[] CriarComByte(string input)
        {
            using (var md5Hash = MD5.Create())
            {
                var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                return data;
            }
        }
    }
}