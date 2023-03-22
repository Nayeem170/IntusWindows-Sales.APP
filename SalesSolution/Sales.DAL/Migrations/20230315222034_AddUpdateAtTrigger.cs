using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.DAL.Migrations
{
    public partial class AddUpdateAtTrigger : Migration
    {
        private const string MIGRATION_SQL_SCRIPT_FILE_NAME_UP = @"20230315222034_AddUpdateAtTrigger_up.sql";
        private const string MIGRATION_SQL_SCRIPT_FILE_NAME_DOWN = @"20230315222034_AddUpdateAtTrigger_down.sql";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = Path.Combine(Directory.GetCurrentDirectory(), "..", "Sales.DAL", "Migrations", "Scripts", MIGRATION_SQL_SCRIPT_FILE_NAME_UP);
            migrationBuilder.Sql(File.ReadAllText(sql));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sql = Path.Combine(Directory.GetCurrentDirectory(), "..", "Sales.DAL", "Migrations", "Scripts", MIGRATION_SQL_SCRIPT_FILE_NAME_DOWN);
            migrationBuilder.Sql(File.ReadAllText(sql));
        }
    }
}
