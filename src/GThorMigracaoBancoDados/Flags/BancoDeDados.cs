using System;
using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner.Processors.Postgres;
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
                case BancoDeDados.Sqlite:
                    return new SQLiteProcessorFactory();
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
                case BancoDeDados.Sqlite:
                    return $"Data Source={ManipulaPastaHelper.LocalSistema()}\\gthor.db;Version=3;";
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
                case BancoDeDados.Sqlite:
                    return "NHibernate.Driver.SQLite20Driver";
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
                case BancoDeDados.Sqlite:
                    return "NHibernate.Dialect.SQLiteDialect";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


    }

    public enum BancoDeDados
    {
        Postgresql,
        Sqlite
    }
}