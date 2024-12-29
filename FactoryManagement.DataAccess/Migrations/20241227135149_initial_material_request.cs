using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FactoryManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial_material_request : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialRequest",
                columns: table => new
                {
                    MaterialRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RequestStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaterialWarehouseID = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialRequest", x => x.MaterialRequestID);
                    table.ForeignKey(
                        name: "FK_MaterialRequest_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialRequest_MaterialWarehouses_MaterialWarehouseID",
                        column: x => x.MaterialWarehouseID,
                        principalTable: "MaterialWarehouses",
                        principalColumn: "MaterialWarehouseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialRequest_AppUserId",
                table: "MaterialRequest",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialRequest_MaterialWarehouseID",
                table: "MaterialRequest",
                column: "MaterialWarehouseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialRequest");
        }
    }
}
