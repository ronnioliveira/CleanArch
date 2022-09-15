using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArch.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO PRODUCTS SELECT 'Mouse', 'Mouse Redragon', '57.1', 21, 'mouseRedragon.jpg', 1");

            migrationBuilder.Sql(
                "INSERT INTO PRODUCTS SELECT 'Receiver', 'Receiver Sony', '210', 30, 'receiverSony.jpg', 2");

            migrationBuilder.Sql(
                "INSERT INTO PRODUCTS SELECT 'Monitor Samung', 'Monitor Samsung G9', '399', 11, 'monitorSamsungG9.jpg', 1");

            migrationBuilder.Sql(
                "INSERT INTO PRODUCTS SELECT 'Mouse Pad', 'Mouse Pad Havit', '9.99', 57, 'mousePadHavit.jpg', 3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM PRODUCTS");
        }
    }
}
