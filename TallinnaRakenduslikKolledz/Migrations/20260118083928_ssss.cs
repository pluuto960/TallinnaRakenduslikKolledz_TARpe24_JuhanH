using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallinnaRakenduslikKolledz.Migrations
{
    /// <inheritdoc />
    public partial class ssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Delinquents",
                table: "Delinquents");

            migrationBuilder.RenameTable(
                name: "Delinquents",
                newName: "Delinquent");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Delinquent",
                table: "Delinquent",
                column: "DelinquentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Delinquent",
                table: "Delinquent");

            migrationBuilder.RenameTable(
                name: "Delinquent",
                newName: "Delinquents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Delinquents",
                table: "Delinquents",
                column: "DelinquentId");
        }
    }
}
