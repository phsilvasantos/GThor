using System;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;

namespace GThorMigracaoBancoDados
{
    public class ExecutaMigracao
    {
        public void Executa()
        {
            IAnnouncer announcer = new TextWriterAnnouncer(Console.Out);

            IRunnerContext migrationContext = new RunnerContext(announcer)
            {
                Connection = "Server=localhost;Port=5432;User ID=postgres;Password=root;",
                Database = "gthor"
            };

            TaskExecutor executor = new TaskExecutor(migrationContext);

            executor.Execute();
        }
    }
}