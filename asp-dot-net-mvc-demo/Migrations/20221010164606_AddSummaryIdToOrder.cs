using Microsoft.EntityFrameworkCore.Migrations;

namespace asp_dot_net_mvc_demo.Migrations
{
    public partial class AddSummaryIdToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SummaryId",
                table: "Orders",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SummaryId",
                table: "Orders");
        }
    }
}
