using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_pro.Migrations
{
    /// <inheritdoc />
    public partial class DeletedsomepartofthemodelS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAssigned",
                table: "Assigments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAssigned",
                table: "Assigments");
        }
    }
}
