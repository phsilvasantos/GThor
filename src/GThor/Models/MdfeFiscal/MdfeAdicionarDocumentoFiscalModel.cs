using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkWpf.Models.Base;

namespace GThor.Models.MdfeFiscal
{
    public class MdfeAdicionarDocumentoFiscalModel : ModelViewBase
    {
        public IList<Uf> UfsPesquisa { get; set; }
    }
}