using System.Collections.Generic;
using System.Linq;
using GThorFrameworkDominio.Dominios.Pessoas;
using GThorFrameworkDominio.Dto;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Implementacao.Base;
using Microsoft.EntityFrameworkCore;

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

        public void SalvarOuAtualizar(Pessoa entity)
        {
            if (Insere(entity)) return;

            Atualiza(entity);
        }

        private bool Insere(Pessoa entity)
        {
            if (entity.Id != 0) return false;

            GThorContexto.Pessoas.Add(entity);

            if (entity.Transportadora != null)
                GThorContexto.Transportadoras.Add(entity.Transportadora);

            if (entity.Condutor != null)
            {
                GThorContexto.Condutores.Add(entity.Condutor);
            }

            return true;
        }

        private void Atualiza(Pessoa entity)
        {
            GThorContexto.Pessoas.Update(entity);

            if (entity.Transportadora != null)
            {
                if (entity.Transportadora.PessoaId != 0)
                {
                    GThorContexto.Transportadoras.Add(entity.Transportadora);
                }
            }
                

            if (entity.Condutor != null)
            {
                if (entity.Condutor.PessoaId != 0)
                {
                    GThorContexto.Condutores.Add(entity.Condutor);
                }
            }
        }

        public Pessoa CarregarPorId(int id)
        {
            return GThorContexto.Pessoas.Include(p => p.Transportadora)
                .Include(p => p.Condutor)
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Pessoa> Lista()
        {
            return GThorContexto.Pessoas.Include(p => p.Transportadora)
                .Include(p => p.Condutor)
                .Take(1000);
        }
    }
}