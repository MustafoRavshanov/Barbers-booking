using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barber.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixAppointmentStartTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointment_services_services_service_id",
                table: "appointment_services");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.CreateTable(
                name: "services_catalogs",
                columns: table => new
                {
                    service_id = table.Column<Guid>(type: "uuid", nullable: false),
                    barber_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    duration_minutes = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services_catalogs", x => x.service_id);
                    table.ForeignKey(
                        name: "FK_services_catalogs_barbers_barber_id",
                        column: x => x.barber_id,
                        principalTable: "barbers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_services_catalogs_barber_id",
                table: "services_catalogs",
                column: "barber_id");

            migrationBuilder.AddForeignKey(
                name: "FK_appointment_services_services_catalogs_service_id",
                table: "appointment_services",
                column: "service_id",
                principalTable: "services_catalogs",
                principalColumn: "service_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointment_services_services_catalogs_service_id",
                table: "appointment_services");

            migrationBuilder.DropTable(
                name: "services_catalogs");

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    service_id = table.Column<Guid>(type: "uuid", nullable: false),
                    barber_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    duration_minutes = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.service_id);
                    table.ForeignKey(
                        name: "FK_services_barbers_barber_id",
                        column: x => x.barber_id,
                        principalTable: "barbers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_services_barber_id",
                table: "services",
                column: "barber_id");

            migrationBuilder.AddForeignKey(
                name: "FK_appointment_services_services_service_id",
                table: "appointment_services",
                column: "service_id",
                principalTable: "services",
                principalColumn: "service_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
