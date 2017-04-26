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

            var deletarTransportadora = entity.Transportadora == null;
            var deletarCondutor = entity.Condutor == null;

            var transportadora = BuscaTransportadoraPorId(entity);

            if (deletarTransportadora && transportadora != null)
            {
                GThorContexto.Transportadoras.Remove(transportadora);
                entity.Transportadora = null;
            }

            if (entity.Transportadora != null)
            {
                if (entity.Transportadora.PessoaId != 0)
                {
                    if (transportadora == null)
                    {
                        GThorContexto.Transportadoras.Add(entity.Transportadora);
                        return;
                    }

                    GThorContexto.Transportadoras.Update(entity.Transportadora);
                }
            }

            var condutor = BuscaCondutorPorId(entity);

            if (deletarCondutor && condutor != null)
            {
                GThorContexto.Condutores.Remove(condutor);
                entity.Condutor = null;
            }

            if (entity.Condutor != null)
            {
                if (entity.Condutor.PessoaId != 0)
                {
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
            var condutor = GThorContexto.Condutores.FirstOrDefault(c => c.PessoaId == entity.Id);
            return condutor;
        }

        private Transportadora BuscaTransportadoraPorId(Pessoa entity)
        {
            var transportadora =
                GThorContexto.Transportadoras.FirstOrDefault(t => t.PessoaId == entity.Id);
            return transportadora;
        }
    }
}