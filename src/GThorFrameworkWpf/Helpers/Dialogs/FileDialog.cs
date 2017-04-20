using Microsoft.Win32;

namespace GThorFrameworkWpf.Helpers.Dialogs
{
    public class FileDialog
    {
        public static string DialogDeArquivo(string filtro)
        {
            var janelaArquivo = new OpenFileDialog
            {
                Filter = filtro
            };

            if (janelaArquivo.ShowDialog() == true)
            {
                return janelaArquivo.FileName;
            }

            return string.Empty;
        }
    }
}