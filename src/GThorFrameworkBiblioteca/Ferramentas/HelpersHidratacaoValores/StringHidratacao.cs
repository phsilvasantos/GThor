namespace ComercialBiblioteca.Ferramentas.HelpersHidratacaoValores
{
    public static class StringHidratacao
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
    }
}