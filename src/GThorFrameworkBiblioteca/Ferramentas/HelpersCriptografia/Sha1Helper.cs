﻿using System.Security.Cryptography;
using System.Text;
using GThorFrameworkBiblioteca.Ferramentas.HelpersHidratacaoValores;

namespace GThorFrameworkBiblioteca.Ferramentas.HelpersCriptografia
{
    public static class Sha1Helper
    {
        public static string Computar(string input)
        {
            if (input.IsNullOrEmpty()) return null;

            using (var sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length*2);

                foreach (var b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        public static byte[] ComputarByte(string input)
        {
            using (var sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));

                return hash;
            }
        }
    }
}