using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FactoryManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialrequesttime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestedAt",
                table: "MaterialRequest",
                newName: "RequestTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestTime",
                table: "MaterialRequest",
                newName: "RequestedAt");
        }
    }
}
