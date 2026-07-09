using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IT.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Renamedescriptioncolumninthedatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PropertyItems",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "PropertyItems",
                newName: "Name");
        }
    }
}
