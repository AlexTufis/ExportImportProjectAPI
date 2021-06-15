using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectAPI.Data.Migrations
{
    public partial class DeletePricingId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricingId",
                table: "Distribuitors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PricingId",
                table: "Distribuitors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
