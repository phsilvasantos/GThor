using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.Empresas;
using GThorFrameworkDominio.Dto;
using GThorFrameworkDominio.Dto.Empresas;
using GThorRepositorio.Contratos;
using GThorRepositorioNHibernate.Imeplementacoes.Base;
using NHibernate.Transform;

namespace GThorRepositorioNHibernate.Imeplementacoes
{
    internal class RepositorioEmpresa : RepositorioBase, IRepositorioEmpresa
    {
        public Empresa CarregarPorId(int id)
        {
            return Sessao.Get<Empresa>(id);
        }

        public IEnumerable<Empresa> Lista()
        {
            return Sessao.QueryOver<Empresa>().List<Empresa>();
        }

        public void SalvarOuAtualizar(Empresa entity)
        {
            Sessao.SaveOrUpdate(entity);
        }

        public void Deletar(Empresa entity)
        {
            Sessao.Delete(entity);
        }

        public IEnumerable<EmpresaDto> BuscarParaGridModel()
        {
            Empresa empresaAlias = null;
            EmpresaDto resultado = null;


            var query = Sessao.QueryOver(() => empresaAlias)
                .SelectList(list => list.Select(() => empresaAlias.Id).WithAlias(() => resultado.Id)
                    .Select(() => empresaAlias.RazaoSocial).WithAlias(() => resultado.RazaoSocial)
                    .Select(() => empresaAlias.NomeFantasia).WithAlias(() => resultado.NomeFantasia)
                    .Select(() => empresaAlias.Cnpj).WithAlias(() => resultado.Cnpj));

            query.TransformUsing(Transformers.AliasToBean<EmpresaDto>());

            var lista = query.List<EmpresaDto>();

            return lista;
        }

        public IEnumerable<EmpresaComboBoxDto> BuscarParaComboBox()
        {
            Empresa empresaAlias = null;
            EmpresaComboBoxDto resultado = null;

            var query = Sessao.QueryOver(() => empresaAlias)
                .SelectList(list => list.Select(() => empresaAlias.Id).WithAlias(() => resultado.Id)
                    .Select(() => empresaAlias.RazaoSocial).WithAlias(() => resultado.RazaoSocial));

            query.TransformUsing(Transformers.AliasToBean<EmpresaComboBoxDto>());

            var lista = query.List<EmpresaComboBoxDto>();

            return lista;
        }
    }
}