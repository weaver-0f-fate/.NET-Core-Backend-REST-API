using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class IsIncomeFieldToOperationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsIncome",
                table: "OperationTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsIncome",
                table: "OperationTypes");
        }
    }
}
