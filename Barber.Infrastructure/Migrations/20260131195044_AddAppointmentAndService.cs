using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barber.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentAndService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_services_catalogs_barbers_barber_id",
                table: "services_catalogs");

            migrationBuilder.DropIndex(
                name: "IX_services_catalogs_barber_id",
                table: "services_catalogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_barber_service_catalog",
                table: "barber_service_catalog");

            migrationBuilder.DropIndex(
                name: "IX_barber_service_catalog_barber_id",
                table: "barber_service_catalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appointment_services",
                table: "appointment_services");

            migrationBuilder.DropIndex(
                name: "IX_appointment_services_appointment_id",
                table: "appointment_services");

            migrationBuilder.DropColumn(
                name: "barber_id",
                table: "services_catalogs");

            migrationBuilder.DropColumn(
                name: "duration_minutes",
                table: "services_catalogs");

            migrationBuilder.DropColumn(
                name: "price",
                table: "services_catalogs");

            migrationBuilder.DropColumn(
                name: "id",
                table: "barber_service_catalog");

            migrationBuilder.DropColumn(
                name: "id",
                table: "appointment_services");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "created_at",
                table: "barber_service_catalog",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "duration_minutes",
                table: "barber_service_catalog",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "barber_service_catalog",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "created_at",
                table: "appointment_services",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "duration_minutes",
                table: "appointment_services",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "appointment_services",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_barber_service_catalog",
                table: "barber_service_catalog",
                columns: new[] { "barber_id", "service_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointment_services",
                table: "appointment_services",
                columns: new[] { "appointment_id", "service_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_barber_service_catalog",
                table: "barber_service_catalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appointment_services",
                table: "appointment_services");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "barber_service_catalog");

            migrationBuilder.DropColumn(
                name: "duration_minutes",
                table: "barber_service_catalog");

            migrationBuilder.DropColumn(
                name: "price",
                table: "barber_service_catalog");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "appointment_services");

            migrationBuilder.DropColumn(
                name: "duration_minutes",
                table: "appointment_services");

            migrationBuilder.DropColumn(
                name: "price",
                table: "appointment_services");

            migrationBuilder.AddColumn<Guid>(
                name: "barber_id",
                table: "services_catalogs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "duration_minutes",
                table: "services_catalogs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "services_catalogs",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                table: "barber_service_catalog",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                table: "appointment_services",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_barber_service_catalog",
                table: "barber_service_catalog",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointment_services",
                table: "appointment_services",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_services_catalogs_barber_id",
                table: "services_catalogs",
                column: "barber_id");

            migrationBuilder.CreateIndex(
                name: "IX_barber_service_catalog_barber_id",
                table: "barber_service_catalog",
                column: "barber_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_services_appointment_id",
                table: "appointment_services",
                column: "appointment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_services_catalogs_barbers_barber_id",
                table: "services_catalogs",
                column: "barber_id",
                principalTable: "barbers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
