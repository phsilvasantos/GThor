using System.Collections.Generic;
using System.Linq;
using GThorFrameworkDominio.Dto;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Implementacao.Base;

namespace GThorRepositorioEntityFramework.Implementacao
{
    internal class RepositorioPessoa : RepositorioBase, IRepositorioPessoa
    {
        public IEnumerable<PessoaDto> BuscarParaGridModel()
        {
            var query = from p in GThorContexto.Pessoas
                select new PessoaDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Cnpj = p.Cnpj,
                    Cpf = p.Cpf
                };

            var lista = query.ToList();

            return lista;
        }
    }
}