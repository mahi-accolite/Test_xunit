using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;

namespace UnitTestMoqFinal
{
    public class FluentMigratorConfig
    {
        public static void Configure(string connectionString)
        {
            var runner = new MyMigrationsRunner(connectionString);
            runner.MigrateUp();
        }
    }
}
