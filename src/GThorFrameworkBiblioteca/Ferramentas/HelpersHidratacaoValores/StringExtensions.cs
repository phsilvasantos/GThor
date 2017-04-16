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
    }
}