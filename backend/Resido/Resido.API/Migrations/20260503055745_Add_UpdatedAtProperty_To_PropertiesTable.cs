using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resido.API.Migrations
{
    /// <inheritdoc />
    public partial class Add_UpdatedAtProperty_To_PropertiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Properties",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Properties");
        }
    }
}
