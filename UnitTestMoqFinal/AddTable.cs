using FluentMigrator;
namespace UnitTestMoqFinal
{
    [Migration(1)]
    public class AddTable : Migration
    {
        public override void Up()
        {
            Create.Table("ProductTable")
                .WithColumn("ProductId").AsInt32().PrimaryKey()
                .WithColumn("ProductName").AsString(50)
                .WithColumn("Desciption").AsString(100);
        }

        public override void Down()
        {
            Delete.Table("ProductTable");
        }
    }
}
