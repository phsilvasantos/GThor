using FluentMigrator;

namespace GThorMigracaoBancoDados.Migracoes
{
    [Migration(131379040782269706)]
    public class InsereEstadosUf : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("uf").Row(new { sigla = "AC", nome = "Acre", codigoIbge = 12 });
            Insert.IntoTable("uf").Row(new { sigla = "AL", nome = "Alagoas", codigoIbge = 27 });
            Insert.IntoTable("uf").Row(new { sigla = "AM", nome = "Amazonas", codigoIbge = 13 });
            Insert.IntoTable("uf").Row(new { sigla = "AP", nome = "Amapá", codigoIbge = 16 });
            Insert.IntoTable("uf").Row(new { sigla = "BA", nome = "Bahia", codigoIbge = 29 });
            Insert.IntoTable("uf").Row(new { sigla = "CE", nome = "Ceará", codigoIbge = 23 });
            Insert.IntoTable("uf").Row(new { sigla = "DF", nome = "Distrito Federal", codigoIbge = 53 });
            Insert.IntoTable("uf").Row(new { sigla = "ES", nome = "Espírito Santo", codigoIbge = 32 });
            Insert.IntoTable("uf").Row(new { sigla = "GO", nome = "Goiás", codigoIbge = 52 });
            Insert.IntoTable("uf").Row(new { sigla = "MA", nome = "Maranhão", codigoIbge = 21 });
            Insert.IntoTable("uf").Row(new { sigla = "MG", nome = "Minas Gerais", codigoIbge = 31 });
            Insert.IntoTable("uf").Row(new { sigla = "MS", nome = "Mato Grosso do Sul", codigoIbge = 50 });
            Insert.IntoTable("uf").Row(new { sigla = "MT", nome = "Mato Grosso", codigoIbge = 51 });
            Insert.IntoTable("uf").Row(new { sigla = "PA", nome = "Pará", codigoIbge = 15 });
            Insert.IntoTable("uf").Row(new { sigla = "PB", nome = "Paraíba", codigoIbge = 25 });
            Insert.IntoTable("uf").Row(new { sigla = "PE", nome = "Pernambuco", codigoIbge = 26 });
            Insert.IntoTable("uf").Row(new { sigla = "PI", nome = "Piauí", codigoIbge = 22 });
            Insert.IntoTable("uf").Row(new { sigla = "PR", nome = "Paraná", codigoIbge = 41 });
            Insert.IntoTable("uf").Row(new { sigla = "RJ", nome = "Rio de Janeiro", codigoIbge = 33 });
            Insert.IntoTable("uf").Row(new { sigla = "RN", nome = "Rio Grande do Norte", codigoIbge = 24 });
            Insert.IntoTable("uf").Row(new { sigla = "RO", nome = "Rondônia", codigoIbge = 11 });
            Insert.IntoTable("uf").Row(new { sigla = "RR", nome = "Roraima", codigoIbge = 14 });
            Insert.IntoTable("uf").Row(new { sigla = "RS", nome = "Rio Grande do Sul", codigoIbge = 43 });
            Insert.IntoTable("uf").Row(new { sigla = "SC", nome = "Santa Catarina", codigoIbge = 42 });
            Insert.IntoTable("uf").Row(new { sigla = "SE", nome = "Sergipe", codigoIbge = 28 });
            Insert.IntoTable("uf").Row(new { sigla = "SP", nome = "São Paulo", codigoIbge = 35 });
            Insert.IntoTable("uf").Row(new { sigla = "TO", nome = "Tocantins", codigoIbge = 17 });
        }

        public override void Down()
        {
            Delete.FromTable("uf").AllRows();
        }
    }
}