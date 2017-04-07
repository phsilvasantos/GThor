using System;

namespace ComercialBiblioteca.Ferramentas.HelpersHidratacaoValores
{
    public static class DecimalHidratacao
    {
        public static decimal Trunca(this decimal input)
        {
            var valor = input;

            valor *= 100;
            valor = Math.Truncate(valor);
            valor /= 100;

            return valor;
        }

        public static decimal Arredonda(this decimal input)
        {
            return Math.Round(input, 2);
        }

        public static decimal Arredonda(this decimal input, int casasDecimais)
        {
            return Math.Round(input, casasDecimais);
        }

        public static decimal ZeraSeNegativo(this decimal input)
        {
            return input < 0.00M ? decimal.Zero : input;
        }
    }
}