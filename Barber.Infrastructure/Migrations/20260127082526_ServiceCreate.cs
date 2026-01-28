using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barber.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ServiceCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "canceled_by",
                table: "appointments");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "locations",
                newName: "district");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "end_breaking_time",
                table: "working_hours",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "start_breaking_time",
                table: "working_hours",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "end_breaking_time",
                table: "working_hours");

            migrationBuilder.DropColumn(
                name: "start_breaking_time",
                table: "working_hours");

            migrationBuilder.RenameColumn(
                name: "district",
                table: "locations",
                newName: "city");

            migrationBuilder.AddColumn<int>(
                name: "canceled_by",
                table: "appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
