using System.IO;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;

namespace ComercialBiblioteca.Ferramentas.HelpersPasta
{
    public class ManipulaPastaHelper
    {
        public ManipulaPastaHelper(string diretorio)
        {
            Diretorio = diretorio;
        }

        public ManipulaPastaHelper Voltar()
        {
            Diretorio = Directory.GetParent(Diretorio).ToString();
            return this;
        }

        public ManipulaPastaHelper CriaPastaSeNaoExistir()
        {
            if (Directory.Exists(Diretorio)) return this;

            Directory.CreateDirectory(Diretorio);
            AdicionaSeguranca();

            return this;
        }

        private void AdicionaSeguranca()
        {
            var dirSec = Directory.GetAccessControl(Diretorio);

            var todos = new SecurityIdentifier(WellKnownSidType.WorldSid, null);

            dirSec.AddAccessRule(new FileSystemAccessRule(todos, FileSystemRights.FullControl, AccessControlType.Allow));

            Directory.SetAccessControl(Diretorio, dirSec);
        }

        public string Diretorio { get; set; }

        public static string LocalSistema()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public ManipulaPastaHelper IrPara(string pasta)
        {
            Diretorio += $"\\{pasta}";
            return this;
        }
    }
}