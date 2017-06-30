using System.Reflection;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors;
using GThorMigracaoBancoDados.Flags;

namespace GThorMigracaoBancoDados
{
    public class ExecutaMigracao
    {
        public void Executa()
        {
            const BancoDeDados bancoDeDados = BancoDeDados.FireBird;

            var connectionString = bancoDeDados.GetStringConexao();

            Announcer announcer = new TextWriterAnnouncer(s => System.Diagnostics.Debug.WriteLine(s));

            announcer.ShowSql = true;

            var assembly = Assembly.GetExecutingAssembly();
            IRunnerContext migrationContext = new RunnerContext(announcer);

            var options = new ProcessorOptions
            {
                PreviewOnly = false,  // set to true to see the SQL
                Timeout = 60
            };

            var factory = bancoDeDados.GetFactory();

            using (var processor = factory.Create(connectionString, announcer, options))
            {
                var runner = new MigrationRunner(assembly, migrationContext, processor);
                runner.MigrateUp(true);
            }
        }
    }
}