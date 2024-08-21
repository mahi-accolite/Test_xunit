using FluentMigrator;
using FluentMigrator.Infrastructure;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors.SqlServer;


namespace UnitTestMoqFinal
{
    public class MyMigrationsRunner : IMigrationRunner
    {
        private string ConnectionString = "";
        public MyMigrationsRunner(string connectionString) 
        {
            this.ConnectionString = connectionString;
        }

        public IMigrationProcessor Processor => throw new NotImplementedException();

        public IMigrationInformationLoader MigrationLoader => throw new NotImplementedException();

        public IAssemblyCollection MigrationAssemblies => throw new NotImplementedException();

        public IRunnerContext RunnerContext => throw new NotImplementedException();

        public IMigrationScope BeginScope()
        {
            throw new NotImplementedException();
        }

        public void Down(IMigration migration)
        {
            throw new NotImplementedException();
        }

        public bool HasMigrationsToApplyDown(long version)
        {
            throw new NotImplementedException();
        }

        public bool HasMigrationsToApplyRollback()
        {
            throw new NotImplementedException();
        }

        public bool HasMigrationsToApplyUp(long? version = null)
        {
            throw new NotImplementedException();
        }

        public void ListMigrations()
        {
            throw new NotImplementedException();
        }

        public bool LoadVersionInfoIfRequired()
        {
            throw new NotImplementedException();
        }

        public void MigrateDown(long version)
        {
            throw new NotImplementedException();
        }

        public void MigrateUp()
        {
            AddTable createTable = new AddTable();
            createTable.Up();
        }

        public void MigrateUp(long version)
        {
            throw new NotImplementedException();
        }

        public void Rollback(int steps)
        {
            throw new NotImplementedException();
        }

        public void RollbackToVersion(long version)
        {
            throw new NotImplementedException();
        }

        public void Up(IMigration migration)
        {
            throw new NotImplementedException();
        }

        public void ValidateVersionOrder()
        {
            throw new NotImplementedException();
        }
    }
}
