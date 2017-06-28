using System;
using System.Text.RegularExpressions;
using GThorFrameworkBiblioteca.Ferramentas.HelpersCriptografia;

namespace GThorFrameworkBiblioteca.Ferramentas.HelpersHidratacaoValores
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string valor)
        {
            return string.IsNullOrEmpty(valor);
        }

        public static bool IsNotNullOrEmpty(this string valor)
        {
            return !IsNullOrEmpty(valor);
        }

        public static string TrimOrEmpty(this string valor)
        {
            return valor?.Trim() ?? string.Empty;
        }

        public static string TrimOrEmptyIsNotNull(this string valor, string mensagemNaoPassouValidao)
        {
            valor = valor.TrimOrEmpty();

            if (valor.IsNullOrEmpty())
            {
                throw new ArgumentException(mensagemNaoPassouValidao);
            }

            return valor;
        }

        public static string TrimOrNull(this string valor)
        {
            return valor?.Trim();
        }

        public static bool IsContemEspacos(this string valor)
        {
            return valor.Contains(" ");
        }

        public static string Sha1(this string valor)
        {
            return Sha1Helper.Computar(valor);
        }

        public static void EumEmail(this string valor)
        {
            var rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            var valido = rg.IsMatch(valor);

            if(!valido) throw new ArgumentException("Xiii, seu email está incorreto reveja ele para nos ok");
        }

        public static void EumCnpj(this string valor)
        {
            if (valor == null)
                throw new ArgumentException("Xiii, seu cnpj está incorreto reveja ele para nos ok");

            var cnpj = valor.Replace(".", "");
            cnpj = cnpj.Replace("/", "");
            cnpj = cnpj.Replace("-", "");

            int[] digitos, soma, resultado;
            int nrDig;
            string ftmt;
            bool[] CNPJOk;
            ftmt = "6543298765432";
            digitos = new int[14];
            soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;
            resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;
            CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;
            try
            {
                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(cnpj.Substring(nrDig, 1));
                    if (nrDig <= 11) soma[0] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1)));
                    if (nrDig <= 12) soma[1] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig, 1)));
                }
                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);
                    if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == 0);
                    else CNPJOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));
                }

                var valido = CNPJOk[0] && CNPJOk[1];

                if(!valido) throw new ArgumentException();
            }
            catch
            {
                throw new ArgumentException("Xiii, seu cnpj está incorreto reveja ele para nos ok");
            }
        }

        public static void EumCpf(this string cpf)
        {
            if (cpf.IsNullOrEmpty())
                throw new ArgumentException("Xiii, seu cpf está incorreto reveja ele para nos ok");

            var valor = cpf.Replace(".", "");
            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                throw new ArgumentException("Xiii, seu cpf está incorreto reveja ele para nos ok");

            var igual = true;
            for (var i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0]) igual = false;
            if (igual || valor == "12345678909") throw new ArgumentException("Xiii, seu cpf está incorreto reveja ele para nos ok");
            var numeros = new int[11];
            for (var i = 0; i < 11; i++) numeros[i] = int.Parse(valor[i].ToString());
            var soma = 0;
            for (var i = 0; i < 9; i++) soma += (10 - i) * numeros[i];
            var resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0) throw new ArgumentException("Xiii, seu cpf está incorreto reveja ele para nos ok");
            }
            else if (numeros[9] != 11 - resultado) throw new ArgumentException("Xiii, seu cpf está incorreto reveja ele para nos ok");
            soma = 0;
            for (var i = 0; i < 10; i++) soma += (11 - i) * numeros[i];
            resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0) throw new ArgumentException("Xiii, seu cpf está incorreto reveja ele para nos ok");
            }
            else if (numeros[10] != 11 - resultado) throw new ArgumentException("Xiii, seu cpf está incorreto reveja ele para nos ok");
        }
    }
}