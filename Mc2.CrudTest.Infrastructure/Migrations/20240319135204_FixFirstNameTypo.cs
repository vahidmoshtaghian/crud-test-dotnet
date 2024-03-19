using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mc2.CrudTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixFirstNameTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirsName",
                schema: "Person",
                table: "Customers",
                newName: "FirstName");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_FirsName_LastName_PhoneNumber",
                schema: "Person",
                table: "Customers",
                newName: "IX_Customers_FirstName_LastName_PhoneNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "Person",
                table: "Customers",
                newName: "FirsName");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_FirstName_LastName_PhoneNumber",
                schema: "Person",
                table: "Customers",
                newName: "IX_Customers_FirsName_LastName_PhoneNumber");
        }
    }
}
