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

            var lista = query.OrderByDescending(p => p.Id).ToList();

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


        private void Atualiza(Pessoa entity)
        {
            GThorContexto.Pessoas.Update(entity);

            if (entity.Transportadora != null)
            {
                if (entity.Transportadora.PessoaId != 0)
                {
                    var transportadora = BuscaTransportadoraPorId(entity);

                    if (transportadora == null)
                    {
                        GThorContexto.Transportadoras.Add(entity.Transportadora);
                        return;
                    }

                    GThorContexto.Transportadoras.Update(entity.Transportadora);
                }
            }


            if (entity.Condutor != null)
            {
                if (entity.Condutor.PessoaId != 0)
                {
                    var condutor = BuscaCondutorPorId(entity);

                    if (condutor == null)
                    {
                        GThorContexto.Condutores.Add(entity.Condutor);
                        return;
                    }

                    GThorContexto.Condutores.Update(entity.Condutor);
                }
            }
        }

        private Condutor BuscaCondutorPorId(Pessoa entity)
        {
            var condutor = GThorContexto.Condutores.FirstOrDefault(c => c.PessoaId == entity.Condutor.PessoaId);
            return condutor;
        }

        private Transportadora BuscaTransportadoraPorId(Pessoa entity)
        {
            var transportadora =
                GThorContexto.Transportadoras.FirstOrDefault(t => t.PessoaId == entity.Transportadora.PessoaId);
            return transportadora;
        }
    }
}