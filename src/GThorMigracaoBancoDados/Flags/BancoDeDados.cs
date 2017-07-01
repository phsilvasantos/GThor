using System;
using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner.Processors.Firebird;
using FluentMigrator.Runner.Processors.MySql;
using FluentMigrator.Runner.Processors.Postgres;
using FluentMigrator.Runner.Processors.SqlServer;
using FluentMigrator.Runner.Processors.SQLite;
using GThorFrameworkBiblioteca.Ferramentas.HelpersPasta;

namespace GThorMigracaoBancoDados.Flags
{
    public static class ExtBancoDeDados
    {
        public static MigrationProcessorFactory GetFactory(this BancoDeDados bancoDeDados)
        {
            switch (bancoDeDados)
            {
                case BancoDeDados.Postgresql:
                    return new PostgresProcessorFactory();
                case BancoDeDados.MySql:
                    return new MySqlProcessorFactory();
                case BancoDeDados.SqlServer2008:
                    return new SqlServer2008ProcessorFactory();
                case BancoDeDados.SqlServerCe40:
                    return new SqlServerCeProcessorFactory();
                case BancoDeDados.Sqlite:
                    return new SQLiteProcessorFactory();
                case BancoDeDados.Firebird:
                    return new FirebirdProcessorFactory();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string GetStringConexao(this BancoDeDados bancoDeDados)
        {
            switch (bancoDeDados)
            {
                case BancoDeDados.Postgresql:
                    return @"Server=localhost;Port=5432;User ID=postgres;Password=root;Database=gthor;";
                case BancoDeDados.MySql:
                    return @"Server=localhost;Database=gthor;UID=root;Password=root";
                case BancoDeDados.Firebird:
                    return $"User=SYSDBA; Password=root; Database={ManipulaPastaHelper.LocalSistema()}\\gthor.fdb; DataSource=localhost; Port=3050;";
                case BancoDeDados.SqlServerCe40:
                    return $"Data Source={ManipulaPastaHelper.LocalSistema()}\\gthor.sdf;Persist Security Info=False;";
                case BancoDeDados.Sqlite:
                    return $"Data Source={ManipulaPastaHelper.LocalSistema()}\\gthor.db;Version=3;";
                case BancoDeDados.SqlServer2008:
                    return
                        @"Data Source=LOCALHOST\GThor;Initial Catalog=GThor;Persist Security Info=True;User ID=sa;Password=root;";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string GetStringDriverNHibernate(this BancoDeDados bancoDeDados)
        {
            switch (bancoDeDados)
            {
                case BancoDeDados.Postgresql:
                    return "NHibernate.Driver.NpgsqlDriver";
                case BancoDeDados.MySql:
                    return "NHibernate.Driver.MySqlDataDriver";
                case BancoDeDados.Firebird:
                    return "NHibernate.Driver.FirebirdClientDriver";
                case BancoDeDados.Sqlite:
                    return "NHibernate.Driver.SQLite20Driver";
                case BancoDeDados.SqlServerCe40:
                    return "NHibernate.Driver.SqlServerCeDriver";
                case BancoDeDados.SqlServer2008:
                    return "NHibernate.Driver.SqlClientDriver";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string GetStringDialectNHibernate(this BancoDeDados bancoDeDados)
        {
            switch (bancoDeDados)
            {
                case BancoDeDados.Postgresql:
                    return "NHibernate.Dialect.PostgreSQL82Dialect";
                case BancoDeDados.MySql:
                    return "NHibernate.Dialect.MySQLDialect";
                case BancoDeDados.Firebird:
                    return "NHibernate.Dialect.FirebirdDialect";
                case BancoDeDados.Sqlite:
                    return "NHibernate.Dialect.SQLiteDialect";
                case BancoDeDados.SqlServerCe40:
                    return "NHibernate.Dialect.MsSqlCe40Dialect";
                case BancoDeDados.SqlServer2008:
                    return "NHibernate.Dialect.MsSql2008Dialect";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


    }

    public enum BancoDeDados
    {
        Postgresql,
        MySql,
        SqlServer2008,
        SqlServerCe40,
        Sqlite,
        Firebird
    }
}