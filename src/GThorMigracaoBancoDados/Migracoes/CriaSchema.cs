using FluentMigrator;

namespace GThorMigracaoBancoDados.Migracoes
{
    [Migration(1)]
    public class CriaSchema : Migration
    {
        public override void Up()
        {
            IfDatabase("teste").Create.Schema("teste");
        }

        public override void Down()
        {
            
        }
    }
}