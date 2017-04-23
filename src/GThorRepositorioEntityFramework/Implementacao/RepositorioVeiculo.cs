﻿using System.Collections.Generic;
using System.Linq;
using GThorFrameworkDominio.Dominios.Veiculos;
using GThorRepositorio.Contratos;
using GThorRepositorioEntityFramework.Implementacao.Base;

namespace GThorRepositorioEntityFramework.Implementacao
{
    internal class RepositorioVeiculo : RepositorioBase, IRepositorioVeiculo
    {
        public Veiculo CarregarPorId(int id)
        {
            return GThorContexto.Veiculos.FirstOrDefault(v => v.Id == id);
        }

        public IEnumerable<Veiculo> Lista()
        {
            return GThorContexto.Veiculos.ToList();
        }

        public void SalvarOuAtualizar(Veiculo entity)
        {
            if (entity.Id == 0)
            {
                GThorContexto.Veiculos.Add(entity);
                return;
            }

            GThorContexto.Veiculos.Update(entity);
        }

        public void Deletar(Veiculo entity)
        {
            GThorContexto.Veiculos.Remove(entity);
        }
    }
}